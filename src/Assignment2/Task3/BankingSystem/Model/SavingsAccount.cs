using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    /// <summary>
    /// Represents a savings account that enforces a minimum balance requirement for withdrawals.
    /// </summary>
    /// <remarks>Withdrawals are permitted only if the remaining balance meets or exceeds the required
    /// minimum.</remarks>
    internal class SavingsAccount : BankAccount
    {
        private const decimal V = 1100.0m;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// Creates a new savings account with an ID, type, and starting money.
        /// </summary>
        /// <param name="accountNumber">The unique number or ID for the account.</param>
        /// <param name="accountType">The type label passed to the class.</param>
        /// <param name="balance">The starting money for the account.</param>
        public SavingsAccount(string accountNumber, string accountType, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.AccountType = "savings";
            this.Balance = balance;
        }

        /// <summary>
        /// Takes money out of the account if the total stays above the minimum limit.
        /// </summary>
        /// <param name="amount">The amount of money to take out.</param>
        /// <returns>The money left in the account, or -1 if it goes below the limit.</returns>
        public override decimal Withdraw(decimal amount)
        {
            if (this.Balance <= V || !(this.Balance - amount >= V))
            {
                Console.WriteLine("Cannot withdraw. Maintain minimum Balance");
                return -1m;
            }

            return this.Balance - amount;
        }
    }
}
