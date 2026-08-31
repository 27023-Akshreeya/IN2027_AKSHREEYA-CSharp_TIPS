using System;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Defines the contract for managing income and expense transactions,
    /// calculating net balance, and persisting data.
    /// </summary>
    public interface IExpenseTrackerRepository
    {
        /// <summary>
        /// Gets or sets the current net balance, calculated as total income minus total expenses.
        /// </summary>
        /// <value>The current net balance, calculated as total income minus total expenses.
        /// </value>
        decimal NetBalance { get; set; }

        /// <summary>
        /// Loads income and expense data from the storage files into memory.
        /// </summary>
        void LoadDataFromFiles();

        /// <summary>
        /// Saves all income and expense data changes to the storage files.
        /// </summary>
        void SaveChangesToFiles();

        /// <summary>
        /// Adds a new expense transaction to the repository.
        /// </summary>
        /// <param name="expense">
        /// The expense object containing the details of the transaction.
        /// </param>
        void AddExpense(Expense expense);

        /// <summary>
        /// Adds a new income transaction to the repository.
        /// </summary>
        /// <param name="income">
        /// The income object containing the details of the transaction.
        /// </param>
        void AddIncome(Income income);

        /// <summary>
        /// Retrieves all income transactions.
        /// </summary>
        /// <returns>
        /// A read-only collection of income records.
        /// </returns>
        IReadOnlyList<Income> GetIncome();

        /// <summary>
        /// Retrieves all expense transactions.
        /// </summary>
        /// <returns>
        /// A read-only collection of expense records.
        /// </returns>
        IReadOnlyList<Expense> GetExpense();

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="existingTransaction">
        /// The income record containing the updated transaction details.
        /// </param>
        void UpdateIncomeRecords(Income existingTransaction);

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        /// <param name="existingTransaction">
        /// The expense record containing the updated transaction details.
        /// </param>
        void UpdateExpenseRecords(Expense existingTransaction);

        /// <summary>
        /// Deletes an income transaction using its unique identifier.
        /// </summary>
        /// <param name="deleteRecordId">
        /// The unique identifier of the income record to delete.
        /// </param>
        void DeleteIncomeRecord(Guid deleteRecordId);

        /// <summary>
        /// Deletes an expense transaction using its unique identifier.
        /// </summary>
        /// <param name="deleteRecordId">
        /// The unique identifier of the expense record to delete.
        /// </param>
        void DeleteExpenseRecord(Guid deleteRecordId);

        /// <summary>
        /// Sets the current net balance to a specified value.
        /// </summary>
        /// <param name="netBalance">The new net balance amount to set.</param>
        void SetNetBalance(decimal netBalance);

        /// <summary>
        /// Retrieves the current net balance.
        /// </summary>
        /// <returns>The current net balance as a <see cref="decimal"/>.</returns>
        decimal GetNetBalance();
    }
}