using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Model;
using BankingSystem.View;
using Microsoft.VisualBasic;

namespace BankingSystem.Repository
{
    /// <summary>
    /// Manages the list of bank accounts and handles saving updates.
    /// </summary>
    public class Repo
    {
        private List<BankAccount> _accounts = new List<BankAccount>();
        private UserConsole _userConsole = new UserConsole();

        /// <summary>
        /// Creates and adds a new savings or checking account to the account collection based on the specified account
        /// details.
        /// </summary>
        /// <param name="newAccountDetails">A tuple containing the account number and account type.</param>
        internal void AddNewAccount((string accountNumber, string accountType) newAccountDetails)
        {
            decimal balance = 0;
            if (newAccountDetails.accountType == "savings")
            {
                BankAccount newAccount = new SavingsAccount(newAccountDetails.accountNumber, newAccountDetails.accountType, balance);
                this._accounts.Add((SavingsAccount)newAccount);
            }
            else
            {
                BankAccount newAccount = new CheckingAccount(newAccountDetails.accountNumber, newAccountDetails.accountType, balance);
                this._accounts.Add((CheckingAccount)newAccount);
            }

            return;
        }

        /// <summary>
        /// Retrieves all bank accounts.
        /// </summary>
        /// <returns>A list containing all bank accounts.</returns>
        internal List<BankAccount> GetAllBankAccounts() => this._accounts;

        /// <summary>
        /// Updates the balance of a specified bank account and outputs information to the console.
        /// </summary>
        /// <param name="newBalance">The new balance to assign to the bank account.</param>
        /// <param name="bank">The bank account to update.</param>
        /// <param name="v">A string used for console output.</param>
        internal void UpdateBankAccount(decimal newBalance, BankAccount bank, string v)
        {
            BankAccount? bankAccount = this._accounts.Find(x => x.AccountNumber == bank.AccountNumber);
            if (bankAccount is null)
            {
                return;
            }

            bankAccount.Balance = newBalance;
            this._userConsole.Wrapper(v);
        }
    }
}
