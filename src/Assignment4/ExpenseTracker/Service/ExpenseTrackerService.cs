using ExpenseTracker.Models;
using ExpenseTracker.Models.Enums;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Provides business logic for managing income and expense transactions.
    /// </summary>
    internal class ExpenseTrackerService
    {
        private readonly Repo _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerService"/> class.
        /// </summary>
        /// <param name="repo">The repository used to store and retrieve transaction data. </param>
        public ExpenseTrackerService(Repo repo)
        {
            this._repo = repo;
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
            this._repo.AddExpense(newExpenseDetails);
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
            this._repo.AddIncome(newIncomeDetails);
            return true;
        }

        /// <summary>
        /// Retrieves income or expense records based on the selected record type.
        /// </summary>
        /// <param name="viewChoice">The record type to retrieve. </param>
        /// <returns> A collection of income or expense records.</returns>
        internal object GetRecords(RecordChoices viewChoice)
        {
            if (viewChoice.Equals(RecordChoices.IncomeRecords))
            {
                return this._repo.GetIncome();
            }

            return this._repo.GetExpense();
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="updateRecordId">The unique identifier of the income transaction to update.</param>
        /// <param name="updateInput"> The new value to be applied.</param>
        /// <param name="updateTransaction">The transaction field to update. </param>
        /// <returns>true if income is updated successfull, otherwise false</returns>
        internal bool UpdateIncomeTransaction(Guid updateRecordId, string updateInput, UpdateTransaction updateTransaction)
        {
            var records = (List<Income>)this.GetRecords(RecordChoices.IncomeRecords);
            var existingTransaction = records.Find(x => x.TransactionID == updateRecordId);
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

            this._repo.UpdateIncomeRecords(existingTransaction, oldAmount);
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
            var records = (List<Expense>)this.GetRecords(RecordChoices.ExpenseRecords);
            var existingTransaction = records.Find(x => x.TransactionID == updateRecordId);
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

            this._repo.UpdateExpenseRecords(existingTransaction, oldAmount);
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
                this._repo.DeleteIncomeRecord(deleteRecordId);
                return true;
            }
            else if (recordChoice.Equals(RecordChoices.ExpenseRecords))
            {
                this._repo.DeleteExpenseRecord(deleteRecordId);
                return true;
            }

            return false;
        }
    }
}
