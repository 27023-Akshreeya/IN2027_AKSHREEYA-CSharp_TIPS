using System;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an expense transaction recorded in the Expense Tracker.
    /// Inherits common transaction properties from the <see cref="Record"/> class.
    /// </summary>
    public class Expense : Record
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class
        /// with the specified expense amount and category.
        /// </summary>
        /// <param name="expenseAmount">
        /// The amount spent in the expense transaction.
        /// </param>
        /// <param name="category">
        /// The category to which the expense belongs (e.g., Food, Travel, Entertainment).
        /// </param>
        public Expense(decimal expenseAmount, string category)
        {
            this.ExpenseAmount = expenseAmount;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the amount spent for this expense transaction.
        /// </summary>
        /// <value>
        /// The amount spent for this expense transaction.
        /// </value>
        public decimal ExpenseAmount { get; set; }

        /// <summary>
        /// Gets or sets the category of the expense.
        /// </summary>
        /// <value>
        ///  The category of the expense.
        /// </value>
        public string Category { get; set; }
    }
}