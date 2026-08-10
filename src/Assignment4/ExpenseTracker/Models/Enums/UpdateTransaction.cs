using System;

namespace ExpenseTracker.Models.Enums
{
    /// <summary>
    /// Represents the fields of a transaction that can be updated.
    /// </summary>
    internal enum UpdateTransaction : byte
    {
        /// <summary>
        /// Indicates that no update option has been selected.
        /// </summary>
        None = 0,

        /// <summary>
        /// Updates the transaction date.
        /// </summary>
        Date = 1,

        /// <summary>
        /// Updates the transaction amount.
        /// </summary>
        Amount = 2,

        /// <summary>
        /// Updates the transaction source (for income) or category (for expense).
        /// </summary>
        SourceorCategory = 3,
    }
}