using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Model;
using BankingSystem.Repository;
using BankingSystem.View;
using Microsoft.VisualBasic;

namespace BankingSystem.ConsoleService
{
    /// <summary>
    /// Provides banking services such as account creation, deposit, and withdrawal operations through a console
    /// interface.
    /// </summary>
    internal class Service
    {
        private UserConsole _userConsole = new UserConsole();
        private Repo _repo = new Repo();
        private List<BankAccount> _bankAccounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class and retrieves all bank accounts.
        /// </summary>
        public Service()
        {
            this._bankAccounts = this._repo.GetAllBankAccounts();
        }

        /// <summary>
        /// Handles user interactions for banking operations, including account creation and transaction management.
        /// </summary>
        internal void BankingOperation()
        {
            bool flag = false;
            while (!flag)
            {
                this._userConsole.Menu();
                var newAccountDetails = this._userConsole.GetAccountDetails();
                if (newAccountDetails.accountNumber == string.Empty || newAccountDetails.accountType == string.Empty)
                {
                    flag = this._userConsole.GetExitChoice();
                    continue;
                }

                if (!this._bankAccounts.Any(x => x.AccountNumber == newAccountDetails.accountNumber))
                {
                    this._repo.AddNewAccount(newAccountDetails);
                }

                this.DisplayUsersAccountDetails(newAccountDetails.accountNumber);
                string? userInput = this._userConsole.SelectAccountOperation();
                if (userInput is null)
                {
                    return;
                }

                this.PerformAccountOperation(userInput, newAccountDetails);
                flag = this._userConsole.GetExitChoice();
            }
        }

        private void DisplayUsersAccountDetails(string accountNumber)
        {
            BankAccount? bank = this._bankAccounts.Find(x => x.AccountNumber == accountNumber);
            if (bank != null)
            {
                Console.WriteLine($"Account Number: {bank.AccountNumber}, Balance: {bank.Balance}, Account Type:{bank.AccountType}");
            }

            return;
        }

        private void PerformAccountOperation(string userInput, (string accountNumber, string accountType) newAccountDetails)
        {
            decimal amount = this._userConsole.GetAmountFromUser(userInput);
            if (amount == 0)
            {
                return;
            }

            BankAccount? bank = this._bankAccounts.Find(x => x.AccountNumber == newAccountDetails.accountNumber);
            if (bank is null || bank.AccountNumber is null || bank.AccountType is null)
            {
                return;
            }

            SavingsAccount savingsAccount = new SavingsAccount(bank.AccountNumber, bank.AccountType, bank.Balance);
            CheckingAccount checkingAccount = new CheckingAccount(bank.AccountNumber, bank.AccountType, bank.Balance);

            if (userInput == "1" && newAccountDetails.accountType == "savings")
            {
                decimal newBalance = savingsAccount.Withdraw(amount);
                if (newBalance == -1m)
                {
                    return;
                }

                this._repo.UpdateBankAccount(newBalance, bank, "withdrawn");
            }
            else if (userInput == "1" && newAccountDetails.accountType == "checking")
            {
                decimal newBalance = checkingAccount.Withdraw(amount);
                if (newBalance == -1m)
                {
                    return;
                }

                this._repo.UpdateBankAccount(newBalance, bank, "withdrawn");
            }
            else if (userInput == "2" && newAccountDetails.accountType == "savings")
            {
                decimal newBalance = savingsAccount.Deposit(amount);
                this._repo.UpdateBankAccount(newBalance, bank, "deposited");
            }
            else
            {
                decimal newBalance = checkingAccount.Deposit(amount);
                this._repo.UpdateBankAccount(newBalance, bank, "deposited");
            }

            return;
        }
    }
}
