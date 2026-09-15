using System;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Manages income and expense transactions and maintains the running net balance of the application.
    /// </summary>
    public class ExpenseTrackerMemoryRepository : IExpenseTrackerRepository
    {
        private readonly ExpenseTrackerFileRepository<Income> _incomeFile;
        private readonly ExpenseTrackerFileRepository<Expense> _expenseFile;

        private List<Expense> _expense = new List<Expense>();
        private List<Income> _income = new List<Income>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerMemoryRepository"/> class
        /// </summary>
        /// <param name="expenseTrackerRepository">
        /// The repository instance used for managing expense and income transactions in memory.
        /// </param>
        public ExpenseTrackerMemoryRepository()
        {
            this._expenseFile = new ExpenseTrackerFileRepository<Expense>("expenses.json");
            this._incomeFile = new ExpenseTrackerFileRepository<Income>("incomes.json");
        }

        /// <summary>
        /// Gets or sets the current net balance calculated from all income and expense transactions.
        /// </summary>
        /// <value>The current net balance
        /// </value>
        public decimal NetBalance { get; set; }

        /// <summary>
        /// to load all the data from the file to the list.
        /// </summary>
        public void LoadDataFromFiles()
        {
            this._expense = this._expenseFile.LoadTransactionsFile();
            this._income = this._incomeFile.LoadTransactionsFile();
        }

        /// <summary>
        /// to save all the transactions in the list onto the file.
        /// </summary>
        public void SaveChangesToFiles()
        {
            this._expenseFile.SaveTransactionsFile(this._expense);
            this._incomeFile.SaveTransactionsFile(this._income);
        }

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
            this._expense.Add(expense);
        }

        /// <summary>
        /// Adds a new income transaction.
        /// </summary>
        /// <param name="income">The income transaction to add.</param>
        public void AddIncome(Income income)
        {
            this._income.Add(income);
        }

        /// <summary>
        /// Retrieves all income transactions.
        /// </summary>
        /// <returns>A list containing all recorded income transactions.</returns>
        public IReadOnlyList<Income> GetIncome() => this._income;

        /// <summary>
        /// Retrieves all expense transactions.
        /// </summary>
        /// <returns>A list containing all recorded expense transactions.</returns>
        public IReadOnlyList<Expense> GetExpense() => this._expense;

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="updateIncome">
        /// The updated income transaction details.
        /// </param>
        public void UpdateIncomeRecords(Income updateIncome)
        {
            var incomeRecord = this._income.Find(x => x.TransactionID.Equals(updateIncome.TransactionID));
            if (incomeRecord != null)
            {
                incomeRecord.Source = updateIncome.Source;
                incomeRecord.Amount = updateIncome.Amount;
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
            var expenseRecord = this._expense.Find(
                x => x.TransactionID == updateExpense.TransactionID);

            if (expenseRecord != null)
            {
                expenseRecord.Category = updateExpense.Category;
                expenseRecord.Amount = updateExpense.Amount;
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
            this._income.RemoveAll(x => x.TransactionID.Equals(deleteRecordId));
        }

        /// <summary>
        /// Deletes an expense transaction.
        /// </summary>
        /// <param name="deleteRecordId">
        /// The unique identifier of the expense transaction to delete.
        /// </param>
        public void DeleteExpenseRecord(Guid deleteRecordId)
        {
            this._expense.RemoveAll(x => x.TransactionID.Equals(deleteRecordId));
        }
    }
}