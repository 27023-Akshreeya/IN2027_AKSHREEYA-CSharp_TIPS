using BankingSystem.Model;

namespace BankingSystem.Repository
{
    /// <summary>
    /// Manages bank account storage.
    /// </summary>
    public class Repo
    {
        private readonly List<BankAccount> _accounts = new ();

        /// <summary>
        /// Adds a new bank account.
        /// </summary>
        /// <param name="account">The account to add.</param>
        internal void AddNewAccount(BankAccount account)
        {
            this._accounts.Add(account);
        }

        /// <summary>
        /// Retrieves all bank accounts.
        /// </summary>
        /// <returns>List of bank accounts.</returns>
        internal List<BankAccount> GetAllBankAccounts()
        {
            return this._accounts;
        }

        /// <summary>
        /// Updates the balance of an existing account.
        /// </summary>
        /// <param name="newBalance">Updated balance.</param>
        /// <param name="account">Account to update.</param>
        internal void UpdateBankAccount(decimal newBalance, BankAccount account)
        {
            BankAccount? existingAccount =
                this._accounts.Find(x => x.AccountNumber == account.AccountNumber);

            if (existingAccount is null)
            {
                return;
            }

            existingAccount.Balance = newBalance;
        }
    }
}