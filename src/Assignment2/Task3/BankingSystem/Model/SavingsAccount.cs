namespace BankingSystem.Model
{
    /// <summary>
    /// Represents a savings account that requires a minimum balance.
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        private const decimal MinimumBalance = 1100m;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="balance">The current balance.</param>
        public SavingsAccount(string accountNumber, decimal balance)
            : base(accountNumber, "savings", balance)
        {
        }

        /// <summary>
        /// Withdraws money from the savings account.
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