namespace ExpenseTracker.Models.Enums
{
    /// <summary>
    /// Represents the available menu options in the Expense Tracker application.
    /// </summary>
    public enum MenuChoices
    {
        /// <summary>
        /// Indicates an invalid or unrecognized menu selection.
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Adds a new expense or income transaction.
        /// </summary>
        AddTransaction,

        /// <summary>
        /// Displays all recorded transactions.
        /// </summary>
        ViewAllTransaction,

        /// <summary>
        /// Shows a summary of transactions, such as total income, expenses, and balance.
        /// </summary>
        TransactionSummary,

        /// <summary>
        /// Modifies specific information of an existing transaction.
        /// </summary>
        EditTransaction,

        /// <summary>
        /// Removes an existing transaction from the system.
        /// </summary>
        DeleteTransaction,

        /// <summary>
        /// Exits the Expense Tracker application.
        /// </summary>
        Exit,
    }
}