using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Models
{
    /// <summary>
    /// Provides validation methods for user input such as menu choices,
    /// names, phone numbers, email addresses, and notes.
    /// </summary>
    public class Helper
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
        public string? IsChoiceValid(string choice)
        {
            if (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
            {
                return "Error! Invalid choice";
            }
            else if (!char.TryParse(choice, out var c))
            {
                return "Enter valid character";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Determines whether the specified string represents a valid integer.
        /// </summary>
        /// <param name="detailtxt">The string to evaluate.</param>
        /// <returns>true if the string is a valid integer; otherwise, false.</returns>
        public bool IsNumchice(string? detailtxt)
        {
            if (string.IsNullOrEmpty(detailtxt) || string.IsNullOrWhiteSpace(detailtxt))
            {
                return false;
            }
            else if (!int.TryParse(detailtxt, out var c))
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
        public string? CheckStrValidity(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                return "Invalid input";
            }
            else
            {
                return null;
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
        public string? CheckNumValidity(string num)
        {
            if (num.Length != 10 || !num.All(char.IsDigit))
            {
                return "Invalid input";
            }
            else
            {
                return null;
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
        public string? CheckEmailValidity(string email)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrEmpty(email) ||
                char.IsSymbol(email[0]) ||
                !email.Contains('@'))
            {
                return "Invalid input";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Validates the notes entered for a contact.
        /// </summary>
        /// <param name="notes">
        /// The notes to validate.
        /// </param>
        /// <returns>
        /// An error message if the notes are invalid; otherwise, <c>null</c>.
        /// </returns>
        public string? CheckNoteslValidity(string notes)
        {
            if (string.IsNullOrEmpty(notes))
            {
                return "Invalid input";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This checks if the contact list is empty and displays a message if no contacts are found.
        /// </summary>
        internal void IscontactsEmpty()
        {
            Console.WriteLine("No contacts found.");
            return;
        }
    }
}