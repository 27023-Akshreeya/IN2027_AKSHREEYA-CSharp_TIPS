using System;
using System.Collections.Generic;
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
    public class ExpenseTrackerViewer
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
        public void DisplayMenu()
        {
            bool exit = false;

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

                        break;

                    case MenuChoices.TransactionSummary:
                        this.DisplayRecordSummary();
                        break;

                    case MenuChoices.EditTransaction:
                        this.UpdateTransactionID();
                        break;

                    case MenuChoices.DeleteTransaction:
                        this.GetDeleteId();
                        break;

                    case MenuChoices.Exit:
                        AnsiConsole.Markup(ExpenseTrackerResource.Exiting);
                        exit = true;
                        return;

                    default:
                        AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                        break;
                }

                string exitchoice = this.GetInputWithAttempts(ExpenseTrackerResource.ExitConfirm, Validator.IsChoiceValid);

                if (exitchoice.Equals(string.Empty))
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
        /// Prompts the user for input and validates it, allowing up to three attempts.
        /// </summary>
        /// <param name="input">The display message or prompt for the user.</param>
        /// <param name="validator">The function used to validate the user's input.</param>
        /// <returns>The validated input string if successful; otherwise, an empty string.</returns>
        private string GetInputWithAttempts(string input, InputValidator validator)
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

            return string.Empty;
        }

        /// <summary>
        /// Deletes a selected transaction.
        /// </summary>
        private void GetDeleteId()
        {
            Console.WriteLine(ExpenseTrackerResource.DeleteOperation);
            var recordChoice = this.GetDisplayDetails();
            if (recordChoice.Equals(RecordChoices.Close))
            {
                return;
            }

            string transactionID = this.GetInputWithAttempts(ExpenseTrackerResource.InputTransactionID, input => Guid.TryParse(input, out _));
            if (!Guid.TryParse(transactionID, out Guid deleteRecordId))
            {
                return;
            }

            if (!this._service.DeleteRecordTransaction(deleteRecordId, recordChoice))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return;
            }

            this.DisplaySuccess(ExpenseTrackerResource.RecordDeleted);
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
            this.DisplayNetBalance(totalIncome, totalExpense);
        }

        /// <summary>
        /// Displays the net balance based on total income and expenses.
        /// </summary>
        /// <param name="totalIncome">The total income amount.</param>
        /// <param name="totalExpense">The total expense amount.</param>
        private void DisplayNetBalance(decimal totalIncome, decimal totalExpense)
        {
            var table = new Table();
            table.AddColumn(ExpenseTrackerResource.NetBalance);
            table.AddColumn($"[bold]{totalIncome - totalExpense}[/]");
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Updates a selected transaction.
        /// </summary>
        private void UpdateTransactionID()
        {
            Console.WriteLine(ExpenseTrackerResource.Updateoperation);
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

            string transactionID = this.GetInputWithAttempts(ExpenseTrackerResource.InputTransactionID, input => Guid.TryParse(input, out _));
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

            Console.Write(ExpenseTrackerResource.choice);
            if (!byte.TryParse(Console.ReadLine(), out byte editChoice))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return;
            }

            switch ((UpdateTransaction)editChoice)
            {
                case UpdateTransaction.Date:
                    if (!this.UpdateDate(recordChoice, updateRecordId))
                    {
                        return;
                    }

                    break;
                case UpdateTransaction.Amount:
                    if (!this.UpdateAmount(recordChoice, updateRecordId))
                    {
                        return;
                    }

                    break;
                case UpdateTransaction.SourceOrCategory:
                    if (!this.UpdateDescription(recordChoice, updateRecordId))
                    {
                        return;
                    }

                    break;
                default:
                    AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                    return;
            }
        }

        /// <summary>
        /// Updates the source or category of a transaction.
        /// </summary>
        /// <param name="recordChoice">The transaction type.</param>
        /// <param name="updateRecordId">The transaction identifier.</param>
        /// <returns>True if the update succeeds; otherwise, false.</returns>
        private bool UpdateDescription(RecordChoices recordChoice, Guid updateRecordId)
        {
            if (recordChoice.Equals(RecordChoices.IncomeRecords))
            {
                string sourceInput = this.GetInputWithAttempts(ExpenseTrackerResource.inputSource, input => !string.IsNullOrEmpty(input));
                if (string.IsNullOrEmpty(sourceInput))
                {
                    return false;
                }

                if (this._service.UpdateTransactionDescription(updateRecordId, sourceInput, RecordChoices.IncomeRecords))
                {
                    this.DisplaySuccess(ExpenseTrackerResource.UpdatedIncome);
                    return true;
                }
            }
            else
            {
                string categoryInput = this.GetInputWithAttempts(ExpenseTrackerResource.inputCategory, input => !string.IsNullOrEmpty(input));
                if (string.IsNullOrEmpty(categoryInput))
                {
                    return false;
                }

                if (this._service.UpdateTransactionDescription(updateRecordId, categoryInput, RecordChoices.ExpenseRecords))
                {
                    this.DisplaySuccess(ExpenseTrackerResource.UpdatedExpense);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Updates the date of a transaction.
        /// </summary>
        /// <param name="recordChoice">The transaction type.</param>
        /// <param name="updateRecordId">The transaction identifier.</param>
        /// <returns>True if the update succeeds; otherwise, false.</returns>
        private bool UpdateDate(RecordChoices recordChoice, Guid updateRecordId)
        {
            string date = this.GetDateOfTransaction();
            if (string.IsNullOrEmpty(date))
            {
                return false;
            }

            if (recordChoice.Equals(RecordChoices.IncomeRecords) && this._service.UpdateTransactionDate(updateRecordId, DateTime.Parse(date), RecordChoices.IncomeRecords))
            {
                this.DisplaySuccess(ExpenseTrackerResource.UpdatedIncome);
                return true;
            }
            else if (this._service.UpdateTransactionDate(updateRecordId, DateTime.Parse(date), RecordChoices.ExpenseRecords))
            {
                this.DisplaySuccess(ExpenseTrackerResource.UpdatedExpense);
                return true;
            }

            this.DisplayFailure("Update failed");
            return false;
        }

        /// <summary>
        /// Updates the amount of a transaction.
        /// </summary>
        /// <param name="recordChoice">The transaction type.</param>
        /// <param name="updateRecordId">The transaction identifier.</param>
        /// <returns>True if the update succeeds; otherwise, false.</returns>
        private bool UpdateAmount(RecordChoices recordChoice, Guid updateRecordId)
        {
            string amountInput = this.GetInputWithAttempts(ExpenseTrackerResource.InputAmount, Validator.IsValidAmount);
            if (string.IsNullOrWhiteSpace(amountInput))
            {
                return false;
            }

            if (recordChoice.Equals(RecordChoices.IncomeRecords) && this._service.UpdateTransactionAmount(updateRecordId, amountInput, RecordChoices.IncomeRecords))
            {
                this.DisplaySuccess(ExpenseTrackerResource.UpdatedIncome);
                return true;
            }
            else if (this._service.UpdateTransactionAmount(updateRecordId, amountInput, RecordChoices.ExpenseRecords))
            {
                this.DisplaySuccess(ExpenseTrackerResource.UpdatedExpense);
                return true;
            }

            this.DisplayFailure("Update failed");
            return false;
        }

        /// <summary>
        /// Displays unsuccessfull operation
        /// </summary>
        /// <param name="message">Un successfull</param>
        private void DisplayFailure(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
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
                totalIncomeAmount += item.Amount;
                table.AddRow(item.Date.ToString("yyyy-MM-dd"), item.TransactionID.ToString(), item.Source, item.Amount.ToString());
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
                totalExpenseAmount += item.Amount;
                table.AddRow(item.Date.ToString("yyyy-MM-dd"), item.TransactionID.ToString(), item.Category, item.Amount.ToString());
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
            string date = this.GetDateOfTransaction();
            if (string.IsNullOrEmpty(date))
            {
                return;
            }

            DateTime.TryParse(date, out DateTime transactionDate);
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
                if (newIncomeDetails != null && this._service.AddNewTransactionRecord(newIncomeDetails, transactionDate))
                {
                    this.DisplaySuccess(ExpenseTrackerResource.addedIncome);
                }
            }
            else
            {
                var newExpenseDetails = this.GetExpenseDetails();
                if (newExpenseDetails != null && this._service.AddNewTransactionRecord(newExpenseDetails, transactionDate))
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
            AnsiConsole.Markup(ExpenseTrackerResource.Success + operation + "\n");
        }

        /// <summary>
        /// Gets the transaction date.
        /// </summary>
        /// <returns>The transaction date.</returns>
        private string GetDateOfTransaction()
        {
            return this.GetInputWithAttempts(ExpenseTrackerResource.inputDate, Validator.IsValidDate);
        }

        /// <summary>
        /// Gets expense details.
        /// </summary>
        /// <returns>An expense record.</returns>
        private Expense GetExpenseDetails()
        {
            string amountInput = this.GetInputWithAttempts(ExpenseTrackerResource.inputExpenseAmount, Validator.IsValidAmount);
            if (string.IsNullOrEmpty(amountInput))
            {
                return null;
            }

            string categoryInput = this.GetInputWithAttempts(ExpenseTrackerResource.inputCategory, input => !string.IsNullOrEmpty(input));
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
        private Income GetIncomeDetails()
        {
            string amountInput = this.GetInputWithAttempts(ExpenseTrackerResource.inputIncomeAmount, Validator.IsValidAmount);
            if (string.IsNullOrEmpty(amountInput))
            {
                return null;
            }

            string sourceInput = this.GetInputWithAttempts(ExpenseTrackerResource.inputSource, input => !string.IsNullOrEmpty(input));
            if (string.IsNullOrEmpty(sourceInput))
            {
                return null;
            }

            return new Income(decimal.Parse(amountInput), sourceInput);
        }
    }
}