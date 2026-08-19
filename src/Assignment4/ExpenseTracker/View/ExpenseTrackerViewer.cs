using ExpenseTracker.Helper;
using ExpenseTracker.Models;
using ExpenseTracker.Models.Enums;
using ExpenseTracker.Service;
using Spectre.Console;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Provides a user interface for interacting with the expense tracker, including displaying menus and handling user selections.
    /// </summary>
    /// <remarks>Interacts with ExpenseTrackerService to manage expense and income operations.</remarks>
    internal class ExpenseTrackerViewer
    {
        private readonly ExpenseTrackerService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerViewer"/> class
        /// with the specified expense tracker service.
        /// </summary>
        /// <param name="service"> The service responsible for managing expense and income transactions.</param>
        public ExpenseTrackerViewer(ExpenseTrackerService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Displays the main menu and handles user interactions for the
        /// </summary>
        internal void DisplayMenu()
        {
            bool exit = false;
            this._service.GetAllFiles();

            while (!exit)
            {
                var panel = new Panel(new Rows(new Markup(ExpenseTrackerResource.ExpenseTracker))).Collapse();
                AnsiConsole.Write(panel);

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuChoices>()
                        .Title(ExpenseTrackerResource.OptionSelection)
                        .UseConverter(choice => choice switch
                        {
                            MenuChoices.AddTransaction => ExpenseTrackerResource.AddTransaction,
                            MenuChoices.ViewAllTransaction => ExpenseTrackerResource.ViewAllTransaction,
                            MenuChoices.TransactionSummary => ExpenseTrackerResource.TransactionSummary,
                            MenuChoices.EditTransaction => ExpenseTrackerResource.EditTransaction,
                            MenuChoices.DeleteTransaction => ExpenseTrackerResource.DeleteTransaction,
                            MenuChoices.Exit => ExpenseTrackerResource.Exit,
                            _ => choice.ToString()
                        })
                        .AddChoices(
                            MenuChoices.AddTransaction,
                            MenuChoices.ViewAllTransaction,
                            MenuChoices.TransactionSummary,
                            MenuChoices.EditTransaction,
                            MenuChoices.DeleteTransaction,
                            MenuChoices.Exit));

                switch (choice)
                {
                    case MenuChoices.AddTransaction:
                        this.GetAddDetails();
                        break;

                    case MenuChoices.ViewAllTransaction:
                        var displayTransaction = this.GetDisplayDetails();

                        if (displayTransaction == RecordChoices.None)
                        {
                            AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                        }
                        else if (displayTransaction == RecordChoices.Empty)
                        {
                            AnsiConsole.Markup(ExpenseTrackerResource.empty);
                        }

                        break;

                    case MenuChoices.TransactionSummary:
                        this.DisplayRecordSummary();
                        break;

                    case MenuChoices.EditTransaction:
                        this.GetTransactionId();
                        break;

                    case MenuChoices.DeleteTransaction:
                        this.GetDeleteId();
                        break;

                    case MenuChoices.Exit:
                        AnsiConsole.Markup(ExpenseTrackerResource.Exiting);
                        this._service.SaveAllFiles();
                        exit = true;
                        return;

                    default:
                        AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                        break;
                }

                string? exitchoice = this.GetInputWithAttemps(
                    ExpenseTrackerResource.ExitConfirm,
                    Validator.IsChoiceValid);

                if (exitchoice == null)
                {
                    continue;
                }

                if (exitchoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    AnsiConsole.Markup(ExpenseTrackerResource.Exiting);
                    exit = true;
                }
            }
        }

        /// <summary>
        /// Gets validated user input.
        /// </summary>
        /// <param name="input">Prompt message.</param>
        /// <param name="validator">Input validator.</param>
        /// <returns>Validated input or null.</returns>
        private string? GetInputWithAttemps(string input, InputValidator validator)
        {
            for (int tries = 3; tries > 0; tries--)
            {
                Console.WriteLine($"\nAttempts remaining: {tries}");
                AnsiConsole.Markup(input);

                string userInput = Console.ReadLine() ?? string.Empty;

                if (validator(userInput))
                {
                    return userInput;
                }

                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
            }

            return null;
        }

        /// <summary>
        /// Deletes a selected transaction.
        /// </summary>
        private void GetDeleteId()
        {
            Console.WriteLine("Delete operation:");
            var recordChoice = this.GetDisplayDetails();
            if (recordChoice.Equals(RecordChoices.Close))
            {
                return;
            }
            else if (recordChoice.Equals(RecordChoices.Empty))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.empty);
                return;
            }

            string transactionID = this.GetInputWithAttemps(ExpenseTrackerResource.InputTransactionID, input => Guid.TryParse(input, out _)) ?? string.Empty;
            if (!Guid.TryParse(transactionID, out Guid deleteRecordId))
            {
                return;
            }

            if (!this._service.DoesTransactionExists(deleteRecordId, recordChoice))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return;
            }

            if (this._service.DeleteRecordTransaction(deleteRecordId, recordChoice))
            {
                this.DisplaySuccess(ExpenseTrackerResource.RecordDeleted);
            }
        }

        /// <summary>
        /// Displays the transaction summary.
        /// </summary>
        private void DisplayRecordSummary()
        {
            var incomeRecords = this._service.GetIncomeRecords();
            var totalIncome = this.ViewIncomeRecords(incomeRecords);
            var expenseRecords = this._service.GetExpenseRecords();
            var totalExpense = this.ViewExpenseRecords(expenseRecords);
            var table = new Table();
            table.AddColumn("[bold]Net Balance[/]");
            table.AddColumn($"[bold]{totalIncome + totalExpense}[/]");
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Updates a selected transaction.
        /// </summary>
        private void GetTransactionId()
        {
            Console.WriteLine("Update operation:");
            var recordChoice = this.GetDisplayDetails();
            if (recordChoice.Equals(RecordChoices.Close))
            {
                return;
            }
            else if (recordChoice.Equals(RecordChoices.Empty))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.empty);
                return;
            }

            string transactionID = this.GetInputWithAttemps(ExpenseTrackerResource.InputTransactionID, input => Guid.TryParse(input, out _)) ?? string.Empty;
            if (!Guid.TryParse(transactionID, out Guid updateRecordId) || !this._service.DoesTransactionExists(updateRecordId, recordChoice))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return;
            }

            if (recordChoice.Equals(RecordChoices.IncomeRecords))
            {
                Console.WriteLine(ExpenseTrackerResource.updateIncomeRecord);
            }
            else
            {
                Console.WriteLine(ExpenseTrackerResource.updateExpenseRecord);
            }

            Console.Write("Enter your choice:");
            if (!byte.TryParse(Console.ReadLine(), out byte editChoice))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return;
            }

            switch ((UpdateTransaction)editChoice)
            {
                case UpdateTransaction.Date:
                    var date = this.GetDateOfTransaction();
                    if (recordChoice.Equals(RecordChoices.IncomeRecords))
                    {
                        if (this._service.UpdateIncomeTransaction(updateRecordId, date.ToString() ?? string.Empty, UpdateTransaction.Date))
                        {
                            this.DisplaySuccess(ExpenseTrackerResource.UpdatedIncome);
                        }

                        break;
                    }

                    if (this._service.UpdateExpenseTransaction(updateRecordId, date.ToString() ?? string.Empty, UpdateTransaction.Date))
                    {
                        this.DisplaySuccess(ExpenseTrackerResource.UpdatedExpense);
                    }

                    break;
                case UpdateTransaction.Amount:
                    string amountInput = this.GetInputWithAttemps(ExpenseTrackerResource.InputAmount, Validator.IsValidAmount) ?? string.Empty;
                    if (string.IsNullOrEmpty(amountInput))
                    {
                        return;
                    }

                    if (recordChoice.Equals(RecordChoices.IncomeRecords))
                    {
                        if (this._service.UpdateIncomeTransaction(updateRecordId, amountInput, UpdateTransaction.Amount))
                        {
                            this.DisplaySuccess(ExpenseTrackerResource.UpdatedIncome);
                        }

                        break;
                    }

                    if (this._service.UpdateExpenseTransaction(updateRecordId, amountInput, UpdateTransaction.Amount))
                    {
                        this.DisplaySuccess(ExpenseTrackerResource.UpdatedExpense);
                    }

                    break;
                case UpdateTransaction.SourceorCategory:
                    if (recordChoice.Equals(RecordChoices.IncomeRecords))
                    {
                        string sourceInput = this.GetInputWithAttemps(ExpenseTrackerResource.inputSource, input => !string.IsNullOrEmpty(input)) ?? string.Empty;
                        if (string.IsNullOrEmpty(sourceInput))
                        {
                            return;
                        }

                        if (this._service.UpdateIncomeTransaction(updateRecordId, sourceInput, UpdateTransaction.SourceorCategory))
                        {
                            this.DisplaySuccess(ExpenseTrackerResource.UpdatedIncome);
                        }
                    }
                    else
                    {
                        string categoryInput = this.GetInputWithAttemps(ExpenseTrackerResource.inputCategory, input => !string.IsNullOrEmpty(input)) ?? string.Empty;
                        if (string.IsNullOrEmpty(categoryInput))
                        {
                            return;
                        }

                        if (this._service.UpdateExpenseTransaction(updateRecordId, categoryInput, UpdateTransaction.SourceorCategory))
                        {
                            this.DisplaySuccess(ExpenseTrackerResource.UpdatedExpense);
                        }
                    }

                    break;
                default:
                    AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                    return;
            }
        }

        /// <summary>
        /// Displays and returns the selected record type.
        /// </summary>
        private RecordChoices GetDisplayDetails()
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<RecordChoices>()
                .Title(ExpenseTrackerResource.AddNewTransaction)
                .UseConverter(choice => choice switch
                {
                    RecordChoices.IncomeRecords => ExpenseTrackerResource.IncomeRecords,
                    RecordChoices.ExpenseRecords => ExpenseTrackerResource.ExpenseRecords,
                    RecordChoices.Close => ExpenseTrackerResource.Close,
                    _ => choice.ToString()
                })
                .AddChoices(new[]
                {
                            RecordChoices.IncomeRecords,
                            RecordChoices.ExpenseRecords,
                            RecordChoices.Close,
                }));
            switch (choice)
            {
                case RecordChoices.IncomeRecords:
                    var incomeRecord = this._service.GetIncomeRecords();
                    if (incomeRecord.Count == 0)
                    {
                        return RecordChoices.Empty;
                    }

                    this.ViewIncomeRecords(incomeRecord);
                    return RecordChoices.IncomeRecords;
                case RecordChoices.ExpenseRecords:
                    var expenseRecord = this._service.GetExpenseRecords();
                    if (expenseRecord.Count == 0)
                    {
                        return RecordChoices.Empty;
                    }

                    this.ViewExpenseRecords(expenseRecord);
                    return RecordChoices.ExpenseRecords;
                case RecordChoices.Close:
                    return RecordChoices.Close;
                default:
                    return RecordChoices.None;
            }
        }

        /// <summary>
        /// Displays income records.
        /// </summary>
        private decimal ViewIncomeRecords(IReadOnlyList<Income> incomeRecord)
        {
            decimal totalIncomeAmount = 0;
            var table = new Table();
            table.AddColumn(ExpenseTrackerResource.Date);
            table.AddColumn(ExpenseTrackerResource.TransactionID);
            table.AddColumn(ExpenseTrackerResource.Source);
            table.AddColumn(ExpenseTrackerResource.IncomeAmountDisplay);

            foreach (var item in incomeRecord)
            {
                totalIncomeAmount += item.IncomeAmount;
                table.AddRow(item.Date.ToString("yyyy-MM-dd"), item.TransactionID.ToString(), item.Source, item.IncomeAmount.ToString());
            }

            var table2 = new Table();
            table2.AddColumn(ExpenseTrackerResource.totalAmount);
            table2.AddColumn($"[bold]{totalIncomeAmount}[/]");

            AnsiConsole.Write(table);
            AnsiConsole.Write(table2);
            return totalIncomeAmount;
        }

        /// <summary>
        /// Displays expense records.
        /// </summary>
        private decimal ViewExpenseRecords(IReadOnlyList<Expense> expenseRecord)
        {
            decimal totalExpenseAmount = 0;
            var table = new Table();
            table.Border(TableBorder.Square);
            table.AddColumn(ExpenseTrackerResource.Date);
            table.AddColumn(ExpenseTrackerResource.TransactionID);
            table.AddColumn(ExpenseTrackerResource.Category);
            table.AddColumn(ExpenseTrackerResource.ExpenseAmountDiplay);
            foreach (var item in expenseRecord)
            {
                totalExpenseAmount -= item.ExpenseAmount;
                table.AddRow(item.Date.ToString("yyyy-MM-dd"), item.TransactionID.ToString(), item.Category, item.ExpenseAmount.ToString());
            }

            var table2 = new Table();
            table2.AddColumn(ExpenseTrackerResource.totalAmount);
            table2.AddColumn($"[bold]{totalExpenseAmount}[/]");

            AnsiConsole.Write(table);
            AnsiConsole.Write(table2);
            return totalExpenseAmount;
        }

        /// <summary>
        /// Collects transaction details from the user.
        /// </summary>
        private void GetAddDetails()
        {
            DateTime? transactionDate = this.GetDateOfTransaction();
            if (transactionDate is null)
            {
                return;
            }

            var newTransaction = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title(ExpenseTrackerResource.AddNewTransaction)
                .AddChoices(new[]
                {
                            ExpenseTrackerResource.AddIncome,
                            ExpenseTrackerResource.AddExpense,
                }));
            if (newTransaction.Equals(ExpenseTrackerResource.AddIncome))
            {
                var newIncomeDetails = this.GetIncomeDetails();
                if (newIncomeDetails != null && transactionDate != null && this._service.AddIncomeTransaction(newIncomeDetails, transactionDate.Value))
                {
                    this.DisplaySuccess(ExpenseTrackerResource.addedIncome);
                }
            }
            else
            {
                var newExpenseDetails = this.GetExpenseDetails();
                if (newExpenseDetails != null && transactionDate != null && this._service.AddExpenseTransaction(newExpenseDetails, transactionDate.Value))
                {
                    this.DisplaySuccess(ExpenseTrackerResource.addedExpense);
                }
            }

            return;
        }

        /// <summary>
        /// Displays a success message.
        /// </summary>
        /// <param name="operation">Operation performed.</param>
        private void DisplaySuccess(string operation)
        {
            AnsiConsole.Markup($"[green]Successfully [/]{operation}\n");
        }

        /// <summary>
        /// Gets the transaction date.
        /// </summary>
        /// <returns>The transaction date.</returns>
        private DateTime? GetDateOfTransaction()
        {
            string inputDate = this.GetInputWithAttemps(ExpenseTrackerResource.inputDate, Validator.IsValidDate) ?? string.Empty;
            if (string.IsNullOrEmpty(inputDate))
            {
                return null;
            }

            return DateTime.Parse(inputDate);
        }

        /// <summary>
        /// Gets expense details.
        /// </summary>
        /// <returns>An expense record.</returns>
        private Expense? GetExpenseDetails()
        {
            string amountInput = this.GetInputWithAttemps(ExpenseTrackerResource.inputExpenseAmount, Validator.IsValidAmount) ?? string.Empty;
            if (string.IsNullOrEmpty(amountInput))
            {
                return null;
            }

            string categoryInput = this.GetInputWithAttemps(ExpenseTrackerResource.inputCategory, input => !string.IsNullOrEmpty(input)) ?? string.Empty;
            if (string.IsNullOrEmpty(categoryInput))
            {
                return null;
            }

            return new Expense(decimal.Parse(amountInput), categoryInput);
        }

        /// <summary>
        /// Gets income details.
        /// </summary>
        /// <returns>An income record.</returns>
        private Income? GetIncomeDetails()
        {
            string amountInput = this.GetInputWithAttemps(ExpenseTrackerResource.inputIncomeAmount, Validator.IsValidAmount) ?? string.Empty;
            if (string.IsNullOrEmpty(amountInput))
            {
                return null;
            }

            string sourceInput = this.GetInputWithAttemps(ExpenseTrackerResource.inputSource, input => !string.IsNullOrEmpty(input)) ?? string.Empty;
            if (string.IsNullOrEmpty(sourceInput))
            {
                return null;
            }

            return new Income(decimal.Parse(amountInput), sourceInput);
        }
    }
}