using System.Linq;

namespace ValueAndReferenceTypes.Presentation
{
    /// <summary>
    /// Provides utility validation checks for user interface inputs.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates that the input string is not empty and contains only letters.
        /// </summary>
        /// <param name="input">The text string to evaluate.</param>
        /// <returns>True if the string contains only letters; otherwise, false.</returns>
        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }
    }
}
