using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Presentation
{
    /// <summary>
    /// Represents a method that validates text input conditions.
    /// </summary>
    /// <param name="input">The text string to validate.</param>
    /// <returns>True if the input meets the validation criteria; otherwise, false.</returns>
    public delegate bool InputValidator(string input);

    /// <summary>
    /// Provides utility validation checks for user inputs.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks if a string is a valid integer within boundaries.
        /// </summary>
        /// <param name="input">The text string to parse.</param>
        /// <returns>True if the input is a valid integer; otherwise, false.</returns>
        public static bool IsInputValid(string input)
        {
            return int.TryParse(input, out int number) && number > int.MinValue && number < int.MaxValue;
        }
    }
}
