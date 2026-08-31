using System;
using System.Collections.Generic;
using ExpenseTracker.Models;
using Spectre.Console;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Manages income and expense transactions and maintains the running net balance of the application.
    /// </summary>
    public class ExpenseTrackerRepository
    {
        private readonly List<Expense> _expenses = new List<Expense>();
        private readonly List<Income> _incomes = new List<Income>();

        /// <summary>
        /// Gets or sets the current net balance.
        /// </summary>
        /// <value>The current net balance calculated from all income and expense transactions.
        /// </value>
        private decimal NetBalance { get; set; }

        /// <summary>
        /// Sets the current net balance to a specified value.
        /// </summary>
        /// <param name="newNetBalance">The new net balance amount to set.</param>
        public void SetNetBalance(decimal newNetBalance)
        {
            this.NetBalance = newNetBalance;
        }

        /// <summary>
        /// Retrieves the current net balance.
        /// </summary>
        /// <returns>The current net balance as a <see cref="decimal"/>.</returns>
        public decimal GetNetBalance()
        {
            return this.NetBalance;
        }

        /// <summary>
        /// Adds a new expense transaction.
        /// </summary>
        /// <param name="expense">The expense transaction to add.</param>
        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
        }

        /// <summary>
        /// Adds a new income transaction.
        /// </summary>
        /// <param name="income">The income transaction to add.</param>
        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        /// <summary>
        /// Retrieves all income transactions.
        /// </summary>
        /// <returns>A list containing all recorded income transactions.</returns>
        public IReadOnlyList<Income> GetIncome() => this._incomes;

        /// <summary>
        /// Retrieves all expense transactions.
        /// </summary>
        /// <returns>A list containing all recorded expense transactions.</returns>
        public IReadOnlyList<Expense> GetExpense() => this._expenses;

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="updateIncome">
        /// The updated income transaction details.
        /// </param>
        public void UpdateIncomeRecords(Income updateIncome)
        {
            var incomeRecord = this._incomes.Find(x => x.TransactionID.Equals(updateIncome.TransactionID));
            if (incomeRecord != null)
            {
                incomeRecord.Source = updateIncome.Source;
                incomeRecord.IncomeAmount = updateIncome.IncomeAmount;
                incomeRecord.Date = updateIncome.Date;
            }
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        /// <param name="updateExpense">
        /// The updated expense transaction details.
        /// </param>
        public void UpdateExpenseRecords(Expense updateExpense)
        {
            var expenseRecord = this._expenses.Find(x => x.TransactionID.Equals(updateExpense.TransactionID));
            if (expenseRecord != null)
            {
                expenseRecord.Category = updateExpense.Category;
                expenseRecord.ExpenseAmount = updateExpense.ExpenseAmount;
                expenseRecord.Date = updateExpense.Date;
            }
        }

        /// <summary>
        /// Deletes an income transaction.
        /// </summary>
        /// <param name="deleteRecordId">
        /// The unique identifier of the income transaction to delete.
        /// </param>
        public void DeleteIncomeRecord(Guid deleteRecordId)
        {
            this._incomes.RemoveAll(x => x.TransactionID.Equals(deleteRecordId));
        }

        /// <summary>
        /// Deletes an expense transaction.
        /// </summary>
        /// <param name="deleteRecordId">
        /// The unique identifier of the expense transaction to delete.
        /// </param>
        public void DeleteExpenseRecord(Guid deleteRecordId)
        {
            this._expenses.RemoveAll(x => x.TransactionID.Equals(deleteRecordId));
        }
    }
}