using System;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the base class for all financial records in the Expense Tracker application.
    /// Provides common properties shared by income and expense transactions.
    /// </summary>
    public abstract class Record
    {
        public Record(decimal amount)
        {
            this.Amount = amount;
        }

        /// <summary>
        /// Gets or sets the date on which the transaction occurred.
        /// </summary>
        /// <value>
        /// The date on which the transaction occurred.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the transaction.
        /// </summary>
        /// <value>
        /// The unique identifier of the transaction.
        /// </value>
        public Guid TransactionID { get; set; }

        /// <summary>
        /// Gets or sets amount
        /// </summary>
        /// <value>
        /// amount
        /// </value>
        public decimal Amount { get; set; }
    }
}