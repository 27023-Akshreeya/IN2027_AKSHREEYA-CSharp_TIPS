using System.Linq;
using System.Net.Mail;
using ContactManager.Models;

namespace ContactManager.Helper
{
    /// <summary>
    /// Provides validation methods for user input such as menu choices,
    /// names, phone numbers, email addresses, and notes.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Checks whether the specified input string is null, empty, or consists only of whitespace characters.
        /// </summary>
        /// <param name="input">Input string to check.</param>
        /// <returns>True if the input is valid, false otherwise.</returns>
        public static bool IsInputValid(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the user's menu choice.
        /// </summary>
        /// <param name="choice">
        /// The menu choice entered by the user.
        /// </param>
        /// <returns>
        /// true if the string is a valid character; otherwise, false. <c>null</c>.
        /// </returns>
        public static bool IsChoiceValid(string choice)
        {
            if (!IsInputValid(choice))
            {
                return false;
            }

            return char.TryParse(choice, out char _);
        }

        /// <summary>
        /// Determines whether the specified string represents a valid integer.
        /// </summary>
        /// <param name="contactDetail">The string to evaluate.</param>
        /// <returns>true if the string is a valid integer; otherwise, false.</returns>
        public static bool IsNumericChoiceValid(string contactDetail)
        {
            if (!IsInputValid(contactDetail))
            {
                return false;
            }

            return int.TryParse(contactDetail, out var _);
        }

        /// <summary>
        /// Validates a text input value.
        /// </summary>
        /// <param name="str">
        /// The string to validate.
        /// </param>
        /// <returns>
        /// true if the string is a valid name; otherwise, false. <c>null</c>.
        /// </returns>
        public static bool IsNameValid(string str)
        {
            if (!IsInputValid(str) || !str.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates a phone number.
        /// </summary>
        /// <param name="num">
        /// The phone number to validate.
        /// </param>
        /// <returns>
        /// true if the string is a valid integer; otherwise, false.<c>null</c>.
        /// </returns>
        public static bool IsPhoneNumberValid(string num)
        {
            if (num.Length != 10 || !num.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">
        /// The email address to validate.
        /// </param>
        /// <returns>
        /// true if the string is a valid email; otherwise, false. <c>null</c>.
        /// </returns>
        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var emailAddress = new MailAddress(email);
                return emailAddress.Address.Equals(email);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates the contact details
        /// </summary>
        /// <param name="newContact">consits of contact details</param>
        /// <returns>returns true if contact is valid, false otherwise</returns>
        public static bool IsContactValid(Contact newContact)
        {
            if (!IsInputValid(newContact.EmailId) || !IsInputValid(newContact.Name) || !IsInputValid(newContact.EmailId))
            {
                return false;
            }

            return true;
        }
    }
}