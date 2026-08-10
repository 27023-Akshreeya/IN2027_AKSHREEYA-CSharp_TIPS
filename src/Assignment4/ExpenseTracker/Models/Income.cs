using System;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an income transaction recorded in the Expense Tracker.
    /// Inherits common transaction properties from the <see cref="Record"/> class.
    /// </summary>
    internal class Income : Record
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class
        /// with the specified income amount and source.
        /// </summary>
        /// <param name="incomeAmount">
        /// The amount received in the income transaction.
        /// </param>
        /// <param name="source">
        /// The source of the income (e.g., Salary, Freelancing, Investment).
        /// </param>
        public Income(decimal incomeAmount, string source)
        {
            this.IncomeAmount = incomeAmount;
            this.Source = source;
        }

        /// <summary>
        /// Gets or sets the amount received for this income transaction.
        /// </summary>
        /// <value>
        /// The amount received for this income transaction.
        /// </value>
        public decimal IncomeAmount { get; set; }

        /// <summary>
        /// Gets or sets the source of the income.
        /// </summary>
        /// <value>
        /// The source of the income.
        /// </value>
        public string Source { get; set; }
    }
}