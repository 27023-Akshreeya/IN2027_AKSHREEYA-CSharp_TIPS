namespace BankingSystem.Model
{
    /// <summary>
    /// Represents a bank account with common account details and operations.
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="accountType">The account type.</param>
        /// <param name="balance">The account balance.</param>
        protected BankAccount(string accountNumber, string accountType, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.AccountType = accountType;
            this.Balance = balance;
        }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.
        /// </value>
        public string AccountNumber { get; }

        /// <summary>
        /// Gets the account type.
        /// </summary>
        /// <value>The account type.
        /// </value>
        public string AccountType { get; }

        /// <summary>
        /// Gets or sets the account balance.
        /// </summary>
        /// <value> The account balance.
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Deposits money into the account.
        /// </summary>
        /// <param name="amount">Amount to be deposited.</param>
        /// <returns>The updated balance.</returns>
        public decimal Deposit(decimal amount)
        {
            return this.Balance + amount;
        }

        /// <summary>
        /// Withdraws money from the account.
        /// </summary>
        /// <param name="amount">Amount to withdraw.</param>
        /// <returns>The updated balance.</returns>
        public abstract decimal Withdraw(decimal amount);
    }
}