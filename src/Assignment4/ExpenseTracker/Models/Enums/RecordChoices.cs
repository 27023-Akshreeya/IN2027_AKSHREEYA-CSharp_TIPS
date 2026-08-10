using System;

namespace ExpenseTracker.Models.Enums
{
    /// <summary>
    /// Represents the available record viewing options in the Expense Tracker application.
    /// </summary>
    internal enum RecordChoices
    {
        /// <summary>
        /// Indicates that no record option has been selected.
        /// </summary>
        None,

        /// <summary>
        /// Displays all income records.
        /// </summary>
        IncomeRecords,

        /// <summary>
        /// Displays all expense records.
        /// </summary>
        ExpenseRecords,

        /// <summary>
        /// Closes the record selection menu and returns to the previous screen.
        /// </summary>
        Close,

        /// <summary>
        /// Denotes empty repository
        /// </summary>
        Empty,
    }
}