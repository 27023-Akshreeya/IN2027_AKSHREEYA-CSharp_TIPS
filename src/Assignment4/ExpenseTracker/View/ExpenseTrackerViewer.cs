using ExpenseTracker.Helper;
using ExpenseTracker.Models;
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

        public ExpenseTrackerViewer(ExpenseTrackerService service)
        {
            this._service = service;
        }

        internal void DisplayMenu()
        {
            bool exit = false;

            while (!exit)
            {
                var panel = new Panel(new Rows(new Markup(ExpenseTrackerResource.ExpenseTracker))).Collapse();
                AnsiConsole.Write(panel);
                var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title(ExpenseTrackerResource.OptionSelection)
                            .AddChoices(new[]
                            {
                            ExpenseTrackerResource.AddTransaction,
                            ExpenseTrackerResource.ViewAllTransaction,
                            ExpenseTrackerResource.transactionBydate,
                            ExpenseTrackerResource.updateTransaction,
                            ExpenseTrackerResource.exit,
                            }));
                switch (choice)
                {
                    case "Add new Transaction":
                        DateTime transactionDate = this.GetDateOfTransaction();
                        var newTransaction = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title(ExpenseTrackerResource.OptionSelection)
                            .AddChoices(new[]
                            {
                            ExpenseTrackerResource.AddIncome,
                            ExpenseTrackerResource.AddExpense,
                            }));
                        if (newTransaction.Equals(ExpenseTrackerResource.AddIncome))
                        {
                            var newIncomeDetails = this.GetIncomeDetails();
                            this._service.AddIncomeTransaction(newIncomeDetails, transactionDate);
                        }
                        else
                        {
                            var newExpenseDetails = this.GetExpenseDetails();
                            this._service.AddExpenseTransaction(newExpenseDetails, transactionDate);
                        }

                        break;
                    case "Update Transaction":
                        break;
                    case "View All Transaction":
                        break;
                    case "View transactions by date":
                        break;
                    case "Exit":
                        AnsiConsole.Markup(ExpenseTrackerResource.Exiting);
                        exit = true;
                        break;
                    default:
                        AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                        break;
                }
            }
        }

        private DateTime GetDateOfTransaction()
        {
            AnsiConsole.Markup(ExpenseTrackerResource.inputDate);
            string dateInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsValidDate(dateInput))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                this.GetDateOfTransaction();
            }

            return DateTime.Parse(dateInput);
        }

        private (decimal amountSpent, string category) GetExpenseDetails()
        {
            Console.Write(ExpenseTrackerResource.inputExpenseAmount);
            string amountInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsValidAmount(amountInput))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return (0, string.Empty);
            }

            Console.Write(ExpenseTrackerResource.inputCategory);
            string categoryInput = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(categoryInput))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return (0, string.Empty);
            }

            decimal amountSpent = decimal.Parse(amountInput);
            return (amountSpent, categoryInput);
        }

        private (decimal incomeAmount, string source) GetIncomeDetails()
        {
            Console.Write(ExpenseTrackerResource.inputIncomeAmount);
            string amountInput = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsValidAmount(amountInput))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return (0, string.Empty);
            }

            Console.Write(ExpenseTrackerResource.inputSource);
            string sourceInput = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(sourceInput))
            {
                AnsiConsole.Markup(ExpenseTrackerResource.InvalidInput);
                return (0, string.Empty);
            }

            decimal incomeAmount = decimal.Parse(amountInput);
            return (incomeAmount, sourceInput);
        }
    }
}
