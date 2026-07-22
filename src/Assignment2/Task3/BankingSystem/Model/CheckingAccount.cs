using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    /// <summary>
    /// Represents a checking account for daily use.
    /// Inherits from the BankAccount base class.
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        private const decimal V = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// Creates a new checking account with an ID, type, and starting money.
        /// </summary>
        /// <param name="accountNumber">The unique number or ID for the account.</param>
        /// <param name="acccountType">The type label passed to the class.</param>
        /// <param name="balance">The starting money for the account.</param>
        public CheckingAccount(string accountNumber, string acccountType, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.AccountType = "checking";
            this.Balance = balance;
        }

        /// <summary>
        /// Takes money out of the checking account if there is cash available.
        /// </summary>
        /// <param name="amount">The amount of money to take out.</param>
        /// <returns>The remaining balance, or -1 if the account is empty.</returns>
        public override decimal Withdraw(decimal amount)
        {
            if (this.Balance <= V)
            {
                Console.WriteLine("Cannot withdraw. Empty Account balance");
                return -1m;
            }

            return this.Balance - amount;
        }
    }
}
