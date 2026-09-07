using System;
using System.Linq;

namespace EmployeeHierarchy.Helper
{
    /// <summary>
    /// Provides internal utility and input validation methods for the employee hierarchy system.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Validates whether the provided employee name is not empty and contains only alphabetic characters.
        /// </summary>
        /// <param name="name">The employee name string to validate.</param>
        /// <returns><see langword="true"/> if the name is valid; otherwise, <see langword="false"/>.</returns>
        internal static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates whether the provided position title matches the allowed organizational roles.
        /// </summary>
        /// <param name="position">The job position string to validate.</param>
        /// <returns><see langword="true"/> if the position is either "manager" or "developer" (case-insensitive); otherwise, <see langword="false"/>.</returns>
        internal static bool IsPositionValid(string position)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                return false;
            }

            return position.ToLower().Equals("manager") || position.ToLower().Equals("developer");
        }

        /// <summary>
        /// Validates whether the raw input salary string is a non-empty, positive numeric value.
        /// </summary>
        /// <param name="input">The raw text input representing the salary.</param>
        /// <returns><see langword="true"/> if the input consists strictly of numeric digits; otherwise, <see langword="false"/>.</returns>
        internal static bool IsSalaryValid(string input)
        {
            return double.TryParse(input, out double salary) && salary > 0;
        }

        /// <summary>
        /// Validates whether the provided choice matches the allowed options.
        /// </summary>
        /// <param name="exitChoice">users exit choice</param>
        /// <returns><see langword="true"/> if the choice is valid and contains only letters; otherwise, <see langword="false"/>.</returns>
        internal static bool IsChoiceValid(string exitChoice)
        {
            if (string.IsNullOrWhiteSpace(exitChoice) || string.IsNullOrEmpty(exitChoice) || !exitChoice.All(char.IsLetter))
            {
                return false;
            }

            return exitChoice.Equals("n", StringComparison.OrdinalIgnoreCase) || exitChoice.Equals("y", StringComparison.OrdinalIgnoreCase);
        }
    }
}
