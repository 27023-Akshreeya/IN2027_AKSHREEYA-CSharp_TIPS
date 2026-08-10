using ExpenseTracker.Models;
using Spectre.Console;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Manages income and expense transactions and maintains
    /// the running net balance of the application.
    /// </summary>
    internal class Repo
    {
        private readonly List<Expense> _expenses = new List<Expense>();
        private readonly List<Income> _incomes = new List<Income>();

        /// <summary>
        /// Occurs whenever the net balance is updated due to
        /// an addition or modification of a transaction.
        /// </summary>
        public event EventHandler<Transactions>? RunningNetBalance;

        /// <summary>
        /// Gets the current net balance calculated from all
        /// income and expense transactions.
        /// </summary>
        /// <value>The current net balance calculated from all
        /// income and expense transactions.
        /// </value>
        public decimal NetBalance { get; private set; }

        /// <summary>
        /// Adds a new expense transaction and updates the net balance.
        /// </summary>
        /// <param name="expense">The expense transaction to add.</param>
        public void AddExpense(Expense expense)
        {
            this.NetBalance -= expense.ExpenseAmount;
            this._expenses.Add(expense);
            this.RunningNetBalance?.Invoke(this, new Transactions(this.NetBalance));
        }

        /// <summary>
        /// Adds a new income transaction and updates the net balance.
        /// </summary>
        /// <param name="income">The income transaction to add.</param>
        internal void AddIncome(Income income)
        {
            this.NetBalance += income.IncomeAmount;
            this._incomes.Add(income);
            this.RunningNetBalance?.Invoke(this, new Transactions(this.NetBalance));
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
        /// <param name="oldAmount">
        /// The original income amount before the update.
        /// </param>
        internal void UpdateIncomeRecords(Income existingTransaction, decimal oldAmount)
        {
            var incomeRecord = this._incomes.Find(x => x.TransactionID == existingTransaction.TransactionID);
            if (incomeRecord != null)
            {
                this.NetBalance -= oldAmount;
                this.NetBalance += existingTransaction.IncomeAmount;
                this.RunningNetBalance?.Invoke(this, new Transactions(this.NetBalance));
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
        /// <param name="oldAmount">
        /// The original expense amount before the update.
        /// </param>
        internal void UpdateExpenseRecords(Expense existingTransaction, decimal oldAmount)
        {
            var expenseRecord = this._expenses.Find(
                x => x.TransactionID == existingTransaction.TransactionID);

            if (expenseRecord != null)
            {
                this.NetBalance += oldAmount;
                this.NetBalance -= existingTransaction.ExpenseAmount;
                this.RunningNetBalance?.Invoke(this, new Transactions(this.NetBalance));
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
            var income = this._incomes.FirstOrDefault(x => x.TransactionID == deleteRecordId);
            if (income != null)
            {
                this.NetBalance -= income.IncomeAmount;
                this.RunningNetBalance?.Invoke(this, new Transactions(this.NetBalance));
                this._incomes.Remove(income);
            }
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
            var expense = this._expenses.FirstOrDefault(x => x.TransactionID == deleteRecordId);
            if (expense != null)
            {
                this.NetBalance += expense.ExpenseAmount;
                this.RunningNetBalance?.Invoke(this, new Transactions(this.NetBalance));
                this._expenses.Remove(expense);
            }
        }
    }
}