using System;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the base class for all financial records in the Expense Tracker application.
    /// </summary>
    public abstract class Record
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Record"/> class with a specified financial amount.
        /// </summary>
        /// <param name="amount">The monetary amount of the financial transaction.</param>
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
        /// Gets or sets the value of the financial transaction.
        /// </summary>
        /// <value>
        /// The monetary value of the transaction.
        /// </value>
        public decimal Amount { get; set; }
    }
}
