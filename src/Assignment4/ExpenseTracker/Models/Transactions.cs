using System;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Provides data for transaction-related events.
    /// </summary>
    public class Transactions : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transactions"/> class
        /// with the specified net balance.
        /// </summary>
        /// <param name="balance">
        /// The current net balance after processing a transaction.
        /// </param>
        public Transactions(decimal balance) => this.NetBalance = balance;

        /// <summary>
        /// Gets the current net balance.
        /// </summary>
        /// <value>
        /// The current net balance.
        /// </value>
        public decimal NetBalance { get; }
    }
}