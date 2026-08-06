using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service
{
    internal class ExpenseTrackerService
    {
        private readonly Repo _repo;

        public ExpenseTrackerService(Repo repo)
        {
            this._repo = repo;
        }

        internal void AddExpenseTransaction((decimal amountSpent, string category) newExpenseDetails, DateTime transactionDate)
        {
            var newExpense = new Expense(this._repo.GetCurrentBalance(), newExpenseDetails.amountSpent, transactionDate, newExpenseDetails.category, Guid.NewGuid());
            this._repo.AddNewTransation(newExpense);
        }

        internal void AddIncomeTransaction((decimal incomeAmount, string source) newIncomeDetails, DateTime transactionDate)
        {
            var newIncome = new Income(this._repo.GetCurrentBalance(), newIncomeDetails.incomeAmount, transactionDate, newIncomeDetails.source, Guid.NewGuid());
            this._repo.AddNewTransation(newIncome);
        }

        internal List<Ledger> DisplayAllTransactions()
        {
            return this._repo.GetLedger();
        }
    }
}
