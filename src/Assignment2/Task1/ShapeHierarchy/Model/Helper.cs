using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_basic.Model
{
    /// <summary>
    /// This class provides helper methods for validating user inputs related to shape selection, color, and dimensions. It includes methods to check if a choice is valid, if a color is defined in the KnownColor enumeration, and if a dimension input is a positive number.
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// This method checks if the user's input choice is valid. A valid choice is a single digit that corresponds to one of the menu options. It returns true if the input is valid and false otherwise.
        /// </summary>
        /// <param name="inputChoice">Check if the input choice is valid</param>
        /// <returns>returns the bool value</returns>
        internal static bool IsChoiceValid(string inputChoice)
        {
            if (string.IsNullOrEmpty(inputChoice) || string.IsNullOrWhiteSpace(inputChoice) || inputChoice.Length != 1 || !inputChoice.All(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method checks if the provided color string is a valid color defined in the System.Drawing.KnownColor enumeration. It returns true if the color is valid and false otherwise.
        /// </summary>
        /// <param name="color">Check is the color is valid</param>
        /// <returns>Returns the bools value</returns>
        internal static bool IsColorValid(string color)
        {
            return Enum.IsDefined(typeof(System.Drawing.KnownColor), color);
        }

        /// <summary>
        /// This method checks if the provided dimension input is a valid positive number. It returns true if the input is a valid positive number and false otherwise.
        /// </summary>
        /// <param name="dimensionInput">Gets dimention as input</param>
        /// <returns> returns the bool of the validity</returns>
        internal static bool IsDimensionValid(string? dimensionInput)
        {
            if (string.IsNullOrWhiteSpace(dimensionInput) || string.IsNullOrEmpty(dimensionInput))
            {
                return false;
            }
            else if (!double.TryParse(dimensionInput, out double length) || length <= 0)
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