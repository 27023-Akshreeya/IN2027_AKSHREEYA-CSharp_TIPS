using System.Linq;
using System.Net.Mail;

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
        /// true if the string is a valid character; otherwise, false. <c>null</c>.
        /// </returns>
        public bool IsChoiceValid(string choice)
        {
            if (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
            {
                return false;
            }

            if (!char.TryParse(choice, out var c))
            {
                return false;
            }

            return true;
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

            if (!int.TryParse(contactDetail, out var c))
            {
                return false;
            }

            return true;
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
        public bool IsNameValid(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || !str.All(char.IsLetterOrDigit))
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
        public bool IsPhoneNumberValid(string num)
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
        public bool IsEmailValid(string email)
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
    }
}