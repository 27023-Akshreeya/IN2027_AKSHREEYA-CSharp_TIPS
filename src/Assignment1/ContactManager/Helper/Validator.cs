using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManager.Helper
{
    /// <summary>
    /// Provides validation methods for user input such as menu choices,
    /// names, phone numbers, email addresses, and notes.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Validates the user's menu choice.
        /// </summary>
        /// <param name="choice">
        /// The menu choice entered by the user.
        /// </param>
        /// <returns>
        /// An error message if the choice is invalid; otherwise, <c>null</c>.
        /// </returns>
        public bool IsChoiceValid(string choice)
        {
            if (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
            {
                return false;
            }
            else if (!char.TryParse(choice, out var c))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified string represents a valid integer.
        /// </summary>
        /// <param name="contactDetail">The string to evaluate.</param>
        /// <returns>true if the string is a valid integer; otherwise, false.</returns>
        public bool IsNumericChoiceValid(string contactDetail)
        {
            if (string.IsNullOrEmpty(contactDetail) || string.IsNullOrWhiteSpace(contactDetail))
            {
                return false;
            }
            else if (!int.TryParse(contactDetail, out var c))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates a text input value.
        /// </summary>
        /// <param name="str">
        /// The string to validate.
        /// </param>
        /// <returns>
        /// An error message if the input is invalid; otherwise, <c>null</c>.
        /// </returns>
        public bool IsNameValid(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || !str.All(char.IsLetterOrDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates a phone number.
        /// </summary>
        /// <param name="num">
        /// The phone number to validate.
        /// </param>
        /// <returns>
        /// An error message if the phone number is invalid; otherwise, <c>null</c>.
        /// </returns>
        public bool IsPhoneNumberValid(string num)
        {
            if (num.Length != 10 || !num.All(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">
        /// The email address to validate.
        /// </param>
        /// <returns>
        /// An error message if the email address is invalid; otherwise, <c>null</c>.
        /// </returns>
        public bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrEmpty(email) ||
                char.IsSymbol(email[0]) ||
                email.Count(i => i == '@') != 1)
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