namespace LINQchallenges.Presentation
{
    /// <summary>
    /// Provides validation utility methods for user interface inputs.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Validates if an input string is a valid decimal price greater than or equal to 1.
        /// </summary>
        /// <param name="inputPrice">The string input representing a price.</param>
        /// <returns>True if the string parses to a valid price threshold; otherwise, false.</returns>
        public static bool IsPriceValid(string inputPrice)
        {
            return decimal.TryParse(inputPrice, out decimal price) && price >= 1;
        }

        /// <summary>
        /// Determines whether the specified input string represents a valid integer.
        /// </summary>
        /// <param name="userInput">The input string to validate.</param>
        /// <returns>True if the input can be parsed as an integer; otherwise, false.</returns>
        internal static bool IsNumberValid(string userInput)
        {
            return int.TryParse(userInput, out int _);
        }
    }
}
