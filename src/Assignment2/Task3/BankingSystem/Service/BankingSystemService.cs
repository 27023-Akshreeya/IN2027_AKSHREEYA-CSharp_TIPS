using BankingSystem.Model;
using BankingSystem.Repository;

namespace BankingSystem.Service
{
    /// <summary>
    /// Provides banking-related operations.
    /// </summary>
    internal class BankingSystemService
    {
        private readonly Repo _repo = new Repo();

        /// <summary>
        /// Gets all bank accounts.
        /// </summary>
        /// <returns>List of bank accounts.</returns>
        public List<BankAccount> GetBankAccounts()
        {
            return this._repo.GetAllBankAccounts();
        }

        /// <summary>
        /// Creates a new bank account if it does not already exist.
        /// </summary>
        /// <param name="accountNumber">Account number.</param>
        /// <param name="accountType">Account type.</param>
        public void CreateAccount(string accountNumber, string accountType)
        {
            if (this._repo.GetAllBankAccounts()
                .Any(x => x.AccountNumber == accountNumber))
            {
                return;
            }

            BankAccount account;
            if (accountType == "savings")
            {
                account = new SavingsAccount(accountNumber, 0);
            }
            else
            {
                account = new CheckingAccount(accountNumber, 0);
            }

            this._repo.AddNewAccount(account);
        }

        /// <summary>
        /// Finds an account by account number.
        /// </summary>
        /// <param name="accountNumber">Account number.</param>
        /// <returns>Matching account or null.</returns>
        public BankAccount? GetAccount(string accountNumber)
        {
            return this._repo.GetAllBankAccounts()
                .Find(x => x.AccountNumber == accountNumber);
        }

        /// <summary>
        /// Deposits money into an account.
        /// </summary>
        /// <param name="accountNumber">Account number.</param>
        /// <param name="amount">Amount to deposit.</param>
        /// <returns>Updated balance.</returns>
        public decimal Deposit(string accountNumber, decimal amount)
        {
            BankAccount? account = this.GetAccount(accountNumber);
            if (account is null)
            {
                return -1;
            }

            decimal newBalance = account.Deposit(amount);
            this._repo.UpdateBankAccount(newBalance, account);
            return newBalance;
        }

        /// <summary>
        /// Withdraws money from an account.
        /// </summary>
        /// <param name="accountNumber">Account number.</param>
        /// <param name="amount">Amount to withdraw.</param>
        /// <returns>Updated balance or -1 if withdrawal fails.</returns>
        public decimal Withdraw(string accountNumber, decimal amount)
        {
            BankAccount? account = this.GetAccount(accountNumber);
            if (account is null)
            {
                return -1;
            }

            decimal newBalance = account.Withdraw(amount);
            if (newBalance == -1)
            {
                return -1;
            }

            this._repo.UpdateBankAccount(newBalance, account);
            return newBalance;
        }
    }
}