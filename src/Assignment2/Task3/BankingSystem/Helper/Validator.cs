namespace BankingSystem.Helper
{
    /// <summary>
    /// Provides simple tools to check if banking inputs are correct.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Checks if the account number is not empty and has only numbers.
        /// </summary>
        /// <param name="inputAccountNumber">The account number text from the user.</param>
        /// <returns>True if it has only numbers; otherwise, false.</returns>
        internal static bool IsAccountNumberValid(string? inputAccountNumber)
        {
            if (string.IsNullOrWhiteSpace(inputAccountNumber) || string.IsNullOrEmpty(inputAccountNumber) || !inputAccountNumber.All(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if the account type is either savings or checking.
        /// </summary>
        /// <param name="inputAccountType">The type text from the user.</param>
        /// <returns>True if it matches savings or checking; otherwise, false.</returns>
        internal static bool IsAccountTypeValid(string? inputAccountType)
        {
            if (string.IsNullOrWhiteSpace(inputAccountType) || string.IsNullOrEmpty(inputAccountType))
            {
                return false;
            }
            else if (inputAccountType.ToLower() != "savings" && inputAccountType.ToLower() != "checking")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if the money amount is not empty and has only numbers.
        /// </summary>
        /// <param name="inputAmount">The amount text from the user.</param>
        /// <returns>True if it has only numbers; otherwise, false.</returns>
        internal static bool IsAmountValid(string? inputAmount)
        {
            if (string.IsNullOrWhiteSpace(inputAmount) || string.IsNullOrEmpty(inputAmount) || !inputAmount.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified user input is a valid choice.
        /// </summary>
        /// <param name="userInput">The user input to validate.</param>
        /// <returns>true if the input is valid; otherwise, false.</returns>
        internal static bool IsUserChoiceVaild(string? userInput)
        {
            if (!(userInput != "1") && !(userInput != "2"))
            {
                return false;
            }

            return true;
        }
    }
}
