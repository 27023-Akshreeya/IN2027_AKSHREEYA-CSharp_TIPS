using System;

namespace ExpenseTracker.Helper
{
    /// <summary>
    /// Represents a method that validates a string input and returns a value indicating whether the input is valid.
    /// </summary>
    /// <param name="input">The input string to validate.</param>
    /// <returns>
    /// <c>true</c> if the input is valid; otherwise, <c>false</c>.
    /// </returns>
    public delegate bool InputValidator(string input);

    /// <summary>
    /// Provides utility methods for validating user input.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates whether the supplied amount is a valid positive decimal value.
        /// </summary>
        /// <param name="inputAmount">The amount entered by the user.</param>
        /// <returns>
        /// <c>true</c> if the amount is a valid decimal number greater than zero;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAmount(string inputAmount)
        {
            return decimal.TryParse(inputAmount, out decimal amount) && amount > 0;
        }

        /// <summary>
        /// Validates whether the supplied string represents a valid date.
        /// </summary>
        /// <param name="inputdate">The date string to validate.</param>
        /// <returns>
        /// <c>true</c> if the string can be parsed as a valid date;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDate(string inputdate)
        {
            return DateTime.TryParse(inputdate, out DateTime date) && !(date > DateTime.Now);
        }

        /// <summary>
        /// Validates whether the user's choice is either 'Y' or 'N',
        /// regardless of letter casing.
        /// </summary>
        /// <param name="choice">The user's choice input.</param>
        /// <returns>
        /// <c>true</c> if the choice is 'Y' or 'N'; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsChoiceValid(string choice)
        {
            if (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
            {
                return false;
            }

            return choice.Equals("n", StringComparison.OrdinalIgnoreCase) ||
                     choice.Equals("y", StringComparison.OrdinalIgnoreCase);
        }
    }
}