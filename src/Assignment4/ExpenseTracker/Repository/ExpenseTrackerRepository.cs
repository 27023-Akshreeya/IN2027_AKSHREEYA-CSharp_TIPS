using ExpenseTracker.Models;
using Spectre.Console;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Manages income and expense transactions and maintains
    /// the running net balance of the application.
    /// </summary>
    internal class ExpenseTrackerRepository
    {
        private readonly ExpenseTrackerFileRepository<Income> _incomeFile;
        private readonly ExpenseTrackerFileRepository<Expense> _expenseFile;

        private List<Expense> _expenses = new List<Expense>();
        private List<Income> _incomes = new List<Income>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerRepository"/> class
        /// and configures the file-based storage systems for expenses and income.
        /// </summary>
        public ExpenseTrackerRepository()
        {
            this._expenseFile = new ExpenseTrackerFileRepository<Expense>("expenses.json");
            this._incomeFile = new ExpenseTrackerFileRepository<Income>("incomes.json");
        }

        /// <summary>
        /// Gets or sets the current net balance calculated from all
        /// income and expense transactions.
        /// </summary>
        /// <value>The current net balance calculated from all
        /// income and expense transactions.
        /// </value>
        public decimal NetBalance { get; set; }

        /// <summary>
        /// to load all the data from the file to the list.
        /// </summary>
        public void LoadDataFromFiles()
        {
            this._expenses = this._expenseFile.LoadAllTransactions();
            this._incomes = this._incomeFile.LoadAllTransactions();
        }

        /// <summary>
        /// to save all the transactions in the list onto the file.
        /// </summary>
        public void SaveChangesToFiles()
        {
            this._expenseFile.SaveAllTransactions(this._expenses);
            this._incomeFile.SaveAllTransactions(this._incomes);
        }

        /// <summary>
        /// Adds a new expense transaction and updates the net balance.
        /// </summary>
        /// <param name="expense">The expense transaction to add.</param>
        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
        }

        /// <summary>
        /// Adds a new income transaction and updates the net balance.
        /// </summary>
        /// <param name="income">The income transaction to add.</param>
        internal void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        /// <summary>
        /// Retrieves all income transactions.
        /// </summary>
        /// <returns>A list containing all recorded income transactions.</returns>
        internal List<Income> GetIncome() => this._incomes;

        /// <summary>
        /// Retrieves all expense transactions.
        /// </summary>
        /// <returns>A list containing all recorded expense transactions.</returns>
        internal List<Expense> GetExpense() => this._expenses;

        /// <summary>
        /// Updates an existing income transaction and recalculates
        /// the net balance based on the new amount.
        /// </summary>
        /// <param name="existingTransaction">
        /// The updated income transaction details.
        /// </param>
        internal void UpdateIncomeRecords(Income existingTransaction)
        {
            var incomeRecord = this._incomes.Find(x => x.TransactionID.Equals(existingTransaction.TransactionID));
            if (incomeRecord != null)
            {
                incomeRecord.Source = existingTransaction.Source;
                incomeRecord.IncomeAmount = existingTransaction.IncomeAmount;
                incomeRecord.Date = existingTransaction.Date;
            }
        }

        /// <summary>
        /// Updates an existing expense transaction and recalculates
        /// the net balance based on the new amount.
        /// </summary>
        /// <param name="existingTransaction">
        /// The updated expense transaction details.
        /// </param>
        internal void UpdateExpenseRecords(Expense existingTransaction)
        {
            var expenseRecord = this._expenses.Find(
                x => x.TransactionID == existingTransaction.TransactionID);

            if (expenseRecord != null)
            {
                expenseRecord.Category = existingTransaction.Category;
                expenseRecord.ExpenseAmount = existingTransaction.ExpenseAmount;
                expenseRecord.Date = existingTransaction.Date;
            }
        }

        /// <summary>
        /// Deletes an income transaction and adjusts the net balance
        /// by removing the income amount.
        /// </summary>
        /// <param name="deleteRecordId">
        /// The unique identifier of the income transaction to delete.
        /// </param>
        internal void DeleteIncomeRecord(Guid deleteRecordId)
        {
            this._incomes.RemoveAll(x => x.TransactionID.Equals(deleteRecordId));
        }

        /// <summary>
        /// Deletes an expense transaction and adjusts the net balance
        /// by restoring the expense amount.
        /// </summary>
        /// <param name="deleteRecordId">
        /// The unique identifier of the expense transaction to delete.
        /// </param>
        internal void DeleteExpenseRecord(Guid deleteRecordId)
        {
            this._expenses.RemoveAll(x => x.TransactionID.Equals(deleteRecordId));
        }
    }
}