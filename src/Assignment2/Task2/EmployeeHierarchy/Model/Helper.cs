using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Provides internal utility and input validation methods for the employee hierarchy system.
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// Validates whether the provided employee name is not empty and contains only alphabetic characters.
        /// </summary>
        /// <param name="name">The employee name string to validate.</param>
        /// <returns><see langword="true"/> if the name is valid and contains only letters; otherwise, <see langword="false"/>.</returns>
        internal bool IsNameValid(string? name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates whether the provided position title matches the allowed organizational roles.
        /// </summary>
        /// <param name="position">The job position string to validate.</param>
        /// <returns><see langword="true"/> if the position is either "manager" or "developer" (case-insensitive); otherwise, <see langword="false"/>.</returns>
        internal bool IsPositionValid(string? position)
        {
            if (string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(position))
            {
                return false;
            }
            else if (position.ToLower() != "manager" && position.ToLower() != "developer")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates whether the raw input salary string is a non-empty, positive numeric value.
        /// </summary>
        /// <param name="input">The raw text input representing the salary.</param>
        /// <returns><see langword="true"/> if the input consists strictly of numeric digits; otherwise, <see langword="false"/>.</returns>
        internal bool IsSalaryValid(string? input)
        {
            if (string.IsNullOrWhiteSpace(input) || !input.All(char.IsDigit) || string.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
