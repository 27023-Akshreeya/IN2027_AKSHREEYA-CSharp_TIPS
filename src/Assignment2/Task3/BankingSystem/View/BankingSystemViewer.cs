using BankingSystem.Helper;
using BankingSystem.Model;
using BankingSystem.Service;

namespace BankingSystem.View
{
    /// <summary>
    /// Handles user interactions through the console.
    /// </summary>
    internal class BankingSystemViewer
    {
        private readonly BankingSystemService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingSystemViewer"/> class.
        /// This instances for service
        /// </summary>
        /// <param name="service">service</param>
        public BankingSystemViewer(BankingSystemService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Starts banking operations.
        /// </summary>
        public void BankingOperation()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("------ Banking System ------");

                var accountDetails = this.GetAccountDetails();

                if (accountDetails.accountNumber == string.Empty)
                {
                    exit = this.GetExitChoice();
                    continue;
                }

                this._service.CreateAccount(
                    accountDetails.accountNumber,
                    accountDetails.accountType);

                BankAccount? account =
                    this._service.GetAccount(accountDetails.accountNumber);

                if (account is not null)
                {
                    this.DisplayAccountDetails(account);
                }

                string? operation = this.SelectAccountOperation();

                if (operation is null)
                {
                    exit = this.GetExitChoice();
                    continue;
                }

                decimal amount = this.GetAmountFromUser(operation);

                if (amount == 0)
                {
                    exit = this.GetExitChoice();
                    continue;
                }

                decimal result;

                if (operation == "1")
                {
                    result = this._service.Withdraw(
                        accountDetails.accountNumber,
                        amount);

                    if (result == -1)
                    {
                        Console.WriteLine("Withdrawal failed.");
                    }
                    else
                    {
                        Console.WriteLine("Amount withdrawn successfully.");
                    }
                }
                else
                {
                    result = this._service.Deposit(
                        accountDetails.accountNumber,
                        amount);

                    Console.WriteLine("Amount deposited successfully.");
                }

                account = this._service.GetAccount(accountDetails.accountNumber);

                if (account is not null)
                {
                    this.DisplayAccountDetails(account);
                }

                exit = this.GetExitChoice();
            }
        }

        /// <summary>
        /// Gets account details from the user.
        /// </summary>
        /// <returns>Account number and account type.</returns>
        public (string accountNumber, string accountType) GetAccountDetails()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine() ?? string.Empty;

            if (!Validator.IsAccountNumberValid(accountNumber))
            {
                Console.WriteLine("Invalid account number.");
                return (string.Empty, string.Empty);
            }

            Console.Write("Enter account type [savings/checking]: ");
            string accountType = Console.ReadLine() ?? string.Empty;

            if (!Validator.IsAccountTypeValid(accountType))
            {
                Console.WriteLine("Invalid account type.");
                return (string.Empty, string.Empty);
            }

            return (accountNumber, accountType.ToLower());
        }

        /// <summary>
        /// Gets the operation choice.
        /// </summary>
        /// <returns>User choice.</returns>
        private string? SelectAccountOperation()
        {
            Console.WriteLine("1. Withdraw\n2. Deposit\nEnter your choice: ");

            string? choice = Console.ReadLine();

            if (!Validator.IsUserChoiceVaild(choice))
            {
                Console.WriteLine("Invalid choice.");
                return null;
            }

            return choice;
        }

        /// <summary>
        /// Gets transaction amount.
        /// </summary>
        /// <param name="operation">Selected operation.</param>
        /// <returns>Amount entered by user.</returns>
        private decimal GetAmountFromUser(string operation)
        {
            if (operation == "1")
            {
                Console.Write("Enter amount to withdraw: ");
            }
            else
            {
                Console.Write("Enter amount to deposit: ");
            }

            string? inputAmount = Console.ReadLine();

            if (!Validator.IsAmountValid(inputAmount))
            {
                Console.WriteLine("Invalid amount.");
                return 0;
            }

            return decimal.Parse(inputAmount);
        }

        /// <summary>
        /// Displays account information.
        /// </summary>
        /// <param name="account">Bank account.</param>
        private void DisplayAccountDetails(BankAccount account)
        {
            Console.WriteLine($"\nAccount Details\nAccount Number : {account.AccountNumber}\nAccount Type: {account.AccountType}\nBalance: {account.Balance}\n");
        }

        /// <summary>
        /// Gets the user's exit choice.
        /// </summary>
        /// <returns>True if user wants to exit.</returns>
        private bool GetExitChoice()
        {
            Console.Write("Do you want to exit [y/n]: ");
            string choice = Console.ReadLine() ?? string.Empty;
            while (choice != "y" && choice != "n")
            {
                Console.WriteLine("Invalid choice.\nDo you want to exit [y/n]: ");
                choice = Console.ReadLine() ?? string.Empty;
            }

            return choice == "y";
        }
    }
}