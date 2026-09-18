using System;
using System.Linq;

namespace ShapeHierarchy.Helper
{
    /// <summary>
    /// Handles User Interface for ShapeHierarchy.
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Checks if input is a single-digit menu choice. Returns true or false.
        /// </summary>
        /// <param name="inputChoice">Check if the input choice is valid</param>
        /// <returns>returns the bool value</returns>
        internal static bool IsChoiceValid(string inputChoice)
        {
            if (string.IsNullOrWhiteSpace(inputChoice) || inputChoice.Length != 1 || !inputChoice.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the color string is a valid KnownColor. Returns true or false.
        /// </summary>
        /// <param name="color">Check is the color is valid</param>
        /// <returns>Returns the bools value</returns>
        internal static bool IsColorValid(string color)
        {
            return Enum.IsDefined(typeof(System.Drawing.KnownColor), color);
        }

        /// <summary>
        /// Checks if the dimension input is a valid positive number. Returns true or false.
        /// </summary>
        /// <param name="dimensionInput">Gets dimension as input</param>
        /// <returns> returns the bool of the validity</returns>
        internal static bool IsDimensionValid(string dimensionInput)
        {
            if (string.IsNullOrWhiteSpace(dimensionInput))
            {
                return false;
            }

            return double.TryParse(dimensionInput, out double length) && length > 0;
        }
    }
}