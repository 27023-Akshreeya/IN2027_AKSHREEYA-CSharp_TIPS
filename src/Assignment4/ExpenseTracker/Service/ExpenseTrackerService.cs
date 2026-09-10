using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ExpenseTrackerRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTrackerService"/> class.
        /// </summary>
        /// <param name="repo">The repository used to store and retrieve transaction data. </param>
        public ExpenseTrackerService(ExpenseTrackerRepository repo)
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
            return record == RecordChoices.IncomeRecords ? this._repo.GetIncome().Any(x => x.TransactionID == transactionID) :
                this._repo.GetExpense().Any(x => x.TransactionID == transactionID);
        }

        /// <summary>
        /// Adds a transaction record and updates the repository's net balance.
        /// </summary>
        /// <param name="newRecordDetails">The expense or income record to add.</param>
        /// <param name="transactionDate">The date to assign to the transaction.</param>
        /// <returns><see langword="true"/> if successfully added; otherwise, <see langword="false"/>.</returns>
        public bool AddNewTransactionRecord(Record newRecordDetails, DateTime transactionDate)
        {
            if (newRecordDetails is null)
            {
                return false;
            }

            newRecordDetails.TransactionID = Guid.NewGuid();
            newRecordDetails.Date = transactionDate;
            decimal netBalance = this._repo.GetNetBalance();
            if (newRecordDetails is Expense newExpenseDetails)
            {
                netBalance -= newExpenseDetails.Amount;
                this._repo.SetNetBalance(netBalance);
                this._repo.AddExpense(newExpenseDetails);
                return true;
            }
            else if (newRecordDetails is Income newIncomeDetails)
            {
                netBalance += newIncomeDetails.Amount;
                this._repo.SetNetBalance(netBalance);
                this._repo.AddIncome(newIncomeDetails);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets income list
        /// </summary>
        /// <returns>the list of income</returns>
        public IReadOnlyList<Income> GetIncomeRecords() => this._repo.GetIncome();

        /// <summary>
        /// Gets the expense list
        /// </summary>
        /// <returns>the list of expense</returns>
        public IReadOnlyList<Expense> GetExpenseRecords() => this._repo.GetExpense();

        /// <summary>
        /// This deletes an existing transaction
        /// </summary>
        /// <param name="deleteRecordId">the id to be deleted</param>
        /// <param name="recordChoice">where income or expense</param>
        /// <returns>true if deletion is successfull, otherwise false</returns>
        public bool DeleteRecordTransaction(Guid deleteRecordId, RecordChoices recordChoice)
        {
            if (!this.DoesTransactionExists(deleteRecordId, recordChoice))
            {
                return false;
            }

            if (recordChoice.Equals(RecordChoices.IncomeRecords))
            {
                var incomes = this.GetIncomeRecords();
                var deleteIncomeRecord = incomes.FirstOrDefault(x => x.TransactionID.Equals(deleteRecordId));
                if (deleteIncomeRecord != null)
                {
                    decimal netBalance = this._repo.GetNetBalance();
                    netBalance -= deleteIncomeRecord.Amount;
                    this._repo.SetNetBalance(netBalance);
                    this._repo.DeleteIncomeRecord(deleteRecordId);
                    return true;
                }
            }
            else if (recordChoice.Equals(RecordChoices.ExpenseRecords))
            {
                var expenses = this.GetExpenseRecords();
                var deleteExpenseRecord = expenses.FirstOrDefault(x => x.TransactionID.Equals(deleteRecordId));
                if (deleteExpenseRecord != null)
                {
                    decimal netBalance = this._repo.GetNetBalance();
                    netBalance += deleteExpenseRecord.Amount;
                    this._repo.SetNetBalance(netBalance);
                    this._repo.DeleteExpenseRecord(deleteRecordId);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retrieves a transaction record by its unique identifier.
        /// </summary>
        /// <param name="transactionID">The transaction identifier.</param>
        /// <param name="record">The record type to search.</param>
        /// <returns>The matching transaction record; otherwise, null.</returns>
        public Record GetRecordByTransactionID(Guid transactionID, RecordChoices record)
        {
            if (record is RecordChoices.ExpenseRecords)
            {
                return this.GetExpenseRecords().FirstOrDefault(t => t.TransactionID.Equals(transactionID));
            }

            return this.GetIncomeRecords().FirstOrDefault(t => t.TransactionID.Equals(transactionID));
        }

        /// <summary>
        /// Updates the date of an existing transaction.
        /// </summary>
        /// <param name="updateRecordId">The transaction identifier.</param>
        /// <param name="date">The new transaction date.</param>
        /// <param name="record">The record type.</param>
        /// <returns>True if the update succeeds; otherwise, false.</returns>
        public bool UpdateTransactionDate(Guid updateRecordId, DateTime date, RecordChoices record)
        {
            var updateRecord = this.GetRecordByTransactionID(updateRecordId, record);
            if (updateRecord is Expense expenseTransaction && expenseTransaction != null)
            {
                expenseTransaction.Date = date;
                return true;
            }
            else if (updateRecord is Income incomeTransaction && incomeTransaction != null)
            {
                incomeTransaction.Date = date;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the amount of an existing transaction and adjusts the net balance.
        /// </summary>
        /// <param name="updateRecordId">The transaction identifier.</param>
        /// <param name="updateAmount">The new amount.</param>
        /// <param name="records">The record type.</param>
        /// <returns>True if the update succeeds; otherwise, false.</returns>
        public bool UpdateTransactionAmount(Guid updateRecordId, string updateAmount, RecordChoices records)
        {
            var updateRecord = this.GetRecordByTransactionID(updateRecordId, records);
            var oldAmount = updateRecord.Amount;
            updateRecord.Amount = decimal.Parse(updateAmount);
            decimal netBalance = this._repo.GetNetBalance();
            if (updateRecord is Expense expenseTransaction && expenseTransaction != null)
            {
                netBalance += oldAmount;
                netBalance -= expenseTransaction.Amount;
                this._repo.SetNetBalance(netBalance);
                return true;
            }
            else if (updateRecord is Income incomeTransaction && incomeTransaction != null)
            {
                netBalance -= oldAmount;
                netBalance += incomeTransaction.Amount;
                this._repo.SetNetBalance(netBalance);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the category of an expense or the source of an income transaction.
        /// </summary>
        /// <param name="updateRecordId">The transaction identifier.</param>
        /// <param name="description">The new category or source value.</param>
        /// <param name="records">The record type.</param>
        /// <returns>True if the update succeeds; otherwise, false.</returns>
        public bool UpdateTransactionDescription(Guid updateRecordId, string description, RecordChoices records)
        {
            var updateRecord = this.GetRecordByTransactionID(updateRecordId, records);
            if (updateRecord is Expense expenseTransaction)
            {
                expenseTransaction.Category = description;
                return true;
            }
            else if (updateRecord is Income incomeTransaction)
            {
                incomeTransaction.Source = description;
                return true;
            }

            return false;
        }
    }
}
