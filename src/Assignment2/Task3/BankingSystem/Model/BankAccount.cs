using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    /// <summary>
    /// Represents a bank account with an account number, balance, and account type.
    /// </summary>
    /// <remarks>Serves as an abstract base class requiring implementation of the Withdraw method.</remarks>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// A string that holds the text or number for the account ID.
        /// </value>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the total money in the account.
        /// </summary>
        /// <value>
        /// A decimal number that shows the current cash available.
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the type of account, like Savings or Checking.
        /// </summary>
        /// <value>
        /// A string that describes what kind of account this is.
        /// </value>
        public string? AccountType { get; set; }

        /// <summary>
        /// Adds money to the account balance.
        /// </summary>
        /// <param name="amount">The amount of money to add.</param>
        /// <returns>The new total balance after the money is added.</returns>
        public decimal Deposit(decimal amount)
        {
            return this.Balance + amount;
        }

        /// <summary>
        /// Takes money out of the account balance.
        /// </summary>
        /// <param name="amount">The amount of money to take out.</param>
        /// <returns>The money left in the account after taking the cash out.</returns>
        public abstract decimal Withdraw(decimal amount);
    }
}
