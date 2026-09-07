namespace BankingSystem.Model
{
    /// <summary>
    /// Represents a checking account.
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        private const decimal MinimumBalance = 0m;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="balance">The current balance.</param>
        public CheckingAccount(string accountNumber, decimal balance)
            : base(accountNumber, "checking", balance)
        {
        }

        /// <summary>
        /// Withdraws money from the checking account.
        /// </summary>
        /// <param name="amount">Amount to withdraw.</param>
        /// <returns>
        /// The updated balance if withdrawal succeeds; otherwise -1.
        /// </returns>
        public override decimal Withdraw(decimal amount)
        {
            decimal remainingBalance = this.Balance - amount;

            if (remainingBalance < MinimumBalance)
            {
                return -1m;
            }

            return remainingBalance;
        }
    }
}