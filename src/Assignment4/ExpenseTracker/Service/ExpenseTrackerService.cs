using ExpenseTracker.Models;
using ExpenseTracker.Models.Enums;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Provides business logic for managing income and expense transactions.
    /// </summary>
    public class ExpenseTrackerService
    {
        private readonly IExpenseTrackerRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerService"/> class.
        /// </summary>
        /// <param name="repo">The repository used to store and retrieve transaction data. </param>
        public ExpenseTrackerService(ExpenseTrackerMemoryRepository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Occurs whenever the net balance is updated due to
        /// an addition or modification of a transaction.
        /// </summary>
        public event EventHandler<Transactions>? RunningNetBalance;

        /// <summary>
        /// Loads all data files into the repository.
        /// </summary>
        public void GetAllFiles()
        {
            this._repo.LoadDataFromFiles();
        }

        /// <summary>
        /// Saves all data files into the repository
        /// </summary>
        public void SaveAllFiles()
        {
            this._repo.SaveChangesToFiles();
        }

        /// <summary>
        /// Determines whether a transaction exists for the specified transaction identifier.
        /// </summary>
        /// <param name="transactionID"> The unique identifier of the transaction to search for. </param>
        /// <param name="record"> Specifies whether to search income or expense records. </param>
        /// <returns>true if the transaction exists; otherwise,false. </returns>
        public bool DoesTransactionExists(Guid transactionID, RecordChoices record)
        {
            return record == RecordChoices.IncomeRecords ? this._repo.GetIncome().Any(x => x.TransactionID == transactionID) : this._repo.GetExpense().Any(x => x.TransactionID == transactionID);
        }

        /// <summary>
        /// Adds a new expense transaction.
        /// </summary>
        /// <param name="newExpenseDetails"> The expense transaction details.</param>
        /// <param name="transactionDate"> The date of the expense transaction.</param>
        /// <returns>true if expense is added successfull, otherwise false</returns>
        internal bool AddExpenseTransaction(Expense newExpenseDetails, DateTime transactionDate)
        {
            if (newExpenseDetails is null)
            {
                return false;
            }

            newExpenseDetails.TransactionID = Guid.NewGuid();
            newExpenseDetails.Date = transactionDate;
            this._repo.NetBalance -= newExpenseDetails.ExpenseAmount;
            this._repo.AddExpense(newExpenseDetails);
            this.RunningNetBalance?.Invoke(this, new Transactions(this._repo.NetBalance));
            return true;
        }

        /// <summary>
        /// Adds a new income transaction.
        /// </summary>
        /// <param name="newIncomeDetails"> The income transaction details.</param>
        /// <param name="transactionDate">The date of the income transaction.</param>
        /// <returns>true if income is added successfull, otherwise false</returns>
        internal bool AddIncomeTransaction(Income newIncomeDetails, DateTime transactionDate)
        {
            if (newIncomeDetails is null)
            {
                return false;
            }

            newIncomeDetails.TransactionID = Guid.NewGuid();
            newIncomeDetails.Date = transactionDate;
            this._repo.NetBalance += newIncomeDetails.IncomeAmount;
            this._repo.AddIncome(newIncomeDetails);
            this.RunningNetBalance?.Invoke(this, new Transactions(this._repo.NetBalance));
            return true;
        }

        /// <summary>
        /// Gets income list
        /// </summary>
        /// <returns>the list of income</returns>
        internal IReadOnlyList<Income> GetIncomeRecords() => this._repo.GetIncome();

        /// <summary>
        /// Gets the expense list
        /// </summary>
        /// <returns>the list of expense</returns>
        internal IReadOnlyList<Expense> GetExpenseRecords() => this._repo.GetExpense();

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="updateRecordId">The unique identifier of the income transaction to update.</param>
        /// <param name="updateInput"> The new value to be applied.</param>
        /// <param name="updateTransaction">The transaction field to update. </param>
        /// <returns>true if income is updated successfull, otherwise false</returns>
        internal bool UpdateIncomeTransaction(Guid updateRecordId, string updateInput, UpdateTransaction updateTransaction)
        {
            var records = this.GetIncomeRecords();
            var existingTransaction = records.FirstOrDefault(x => x.TransactionID == updateRecordId);
            if (existingTransaction is null)
            {
                return false;
            }

            var oldAmount = existingTransaction.IncomeAmount;
            switch (updateTransaction)
            {
                case UpdateTransaction.Date:
                    DateTime.TryParse(updateInput, out DateTime updateDate);
                    existingTransaction.Date = updateDate;
                    break;
                case UpdateTransaction.Amount:
                    decimal.TryParse(updateInput, out decimal updateAmount);
                    existingTransaction.IncomeAmount = updateAmount;
                    break;
                case UpdateTransaction.SourceorCategory:
                    existingTransaction.Source = updateInput;
                    break;
                default:
                    return false;
            }

            this._repo.NetBalance -= oldAmount;
            this._repo.NetBalance += existingTransaction.IncomeAmount;
            this.RunningNetBalance?.Invoke(this, new Transactions(this._repo.NetBalance));
            this._repo.UpdateIncomeRecords(existingTransaction);
            return true;
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        /// <param name="updateRecordId">The unique identifier of the expense transaction to update.</param>
        /// <param name="updateInput">The new value to be applied.</param>
        /// <param name="updateTransaction">true if income is updated successfull, otherwise false</param>
        /// <returns>true if expense is updated successfull, otherwise false.</returns>
        internal bool UpdateExpenseTransaction(Guid updateRecordId, string updateInput, UpdateTransaction updateTransaction)
        {
            var records = this.GetExpenseRecords();
            var existingTransaction = records.FirstOrDefault(x => x.TransactionID == updateRecordId);
            if (existingTransaction is null)
            {
                return false;
            }

            var oldAmount = existingTransaction.ExpenseAmount;
            switch (updateTransaction)
            {
                case UpdateTransaction.Date:
                    DateTime.TryParse(updateInput, out DateTime updateDate);
                    existingTransaction.Date = updateDate;
                    break;
                case UpdateTransaction.Amount:
                    decimal.TryParse(updateInput, out decimal updateAmount);
                    existingTransaction.ExpenseAmount = updateAmount;
                    break;
                case UpdateTransaction.SourceorCategory:
                    existingTransaction.Category = updateInput;
                    break;
                default:
                    return false;
            }

            this._repo.NetBalance += oldAmount;
            this._repo.NetBalance -= existingTransaction.ExpenseAmount;
            this.RunningNetBalance?.Invoke(this, new Transactions(this._repo.NetBalance));
            this._repo.UpdateExpenseRecords(existingTransaction);
            return true;
        }

        /// <summary>
        /// Thia deletes an existing transaction
        /// </summary>
        /// <param name="deleteRecordId">the id to be deleted</param>
        /// <param name="recordChoice">where income or expense</param>
        /// <returns>true if deletion is successfull, otherwise false</returns>
        internal bool DeleteRecordTransaction(Guid deleteRecordId, RecordChoices recordChoice)
        {
            if (recordChoice.Equals(RecordChoices.IncomeRecords))
            {
                var incomes = this.GetIncomeRecords();
                var deleteIncome = incomes.FirstOrDefault(x => x.TransactionID.Equals(deleteRecordId));
                if (deleteIncome != null)
                {
                    this._repo.NetBalance -= deleteIncome.IncomeAmount;
                    this.RunningNetBalance?.Invoke(this, new Transactions(this._repo.NetBalance));
                    this._repo.DeleteIncomeRecord(deleteRecordId);
                    return true;
                }
            }
            else if (recordChoice.Equals(RecordChoices.ExpenseRecords))
            {
                var expenses = this.GetExpenseRecords();
                var deleteExpense = expenses.FirstOrDefault(x => x.TransactionID == deleteRecordId);
                if (deleteExpense != null)
                {
                    this._repo.NetBalance += deleteExpense.ExpenseAmount;
                    this.RunningNetBalance?.Invoke(this, new Transactions(this._repo.NetBalance));
                    this._repo.DeleteExpenseRecord(deleteRecordId);
                    return true;
                }
            }

            return false;
        }
    }
}
