using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Model;

namespace BankingSystem.View
{
    /// <summary>
    /// Handles showing menus and getting data from the user in the console interface.
    /// </summary>
    internal class UserConsole
    {
        private Helper _helper = new Helper();

        /// <summary>
        /// Displays the header for the banking system menu.
        /// </summary>
        public void Menu()
        {
            Console.WriteLine("------Banking System------");
        }

        /// <summary>
        /// Asks the user for their account number and type, then checks if they are valid.
        /// </summary>
        /// <returns>A pair of strings containing the number and type, or null values if invalid.</returns>
        public (string accountNumber, string accountType) GetAccountDetails()
        {
            Console.Write("Enter account Number:");
            string? inputAccountNumber = Console.ReadLine();
            if (inputAccountNumber is null || !this._helper.IsAccountNumberValid(inputAccountNumber))
            {
                Console.WriteLine("Invalid account number");
                return (string.Empty, string.Empty);
            }

            Console.Write("Enter account type [savings/checking]:");
            string? inputAccountType = Console.ReadLine();
            if (inputAccountType is null || !this._helper.IsAccountTypeValid(inputAccountType))
            {
                Console.WriteLine("Invalid Account type");
                return (string.Empty, string.Empty);
            }

            return (inputAccountNumber, inputAccountType);
        }

        /// <summary>
        /// Asks the user for a cash amount based on the action they want to take.
        /// </summary>
        /// <param name="userInput">The action choice ("1" for withdraw, or other for deposit).</param>
        /// <returns>The numerical money amount, or 0 if the input text is bad.</returns>
        internal string? SelectAccountOperation()
        {
            Console.Write("Select operation\n1.Withdaw\n2.Deposit\nEnter your choice:");
            string? userInput = Console.ReadLine();
            if (userInput is null || !this._helper.IsUserChoiceVaild(userInput))
            {
                Console.WriteLine("Invalid choice");
                return null;
            }

            return userInput;
        }

        /// <summary>
        /// Asks the user for a cash amount based on the action they want to take.
        /// </summary>
        /// <param name="userInput">The action choice ("1" for withdraw, or other for deposit).</param>
        /// <returns>The numerical money amount, or 0 if the input text is bad.</returns>
        internal decimal GetAmountFromUser(string userInput)
        {
            string? inputAmount = "0";
            if (userInput == "1")
            {
                Console.Write("Enter amount to be withdrawn:");
                inputAmount = Console.ReadLine();
            }
            else
            {
                Console.Write("Enter amount to deposit:");
                inputAmount = Console.ReadLine();
            }

            if (inputAmount is null || !this._helper.IsAmountValid(inputAmount))
            {
                Console.WriteLine("Invalid Amount");
                return 0;
            }

            return decimal.Parse(inputAmount);
        }

        /// <summary>
        /// Prints a success message to the screen using a descriptive text label.
        /// </summary>
        /// <param name="v">The action message text to show.</param>
        internal void Wrapper(string v)
        {
            Console.WriteLine($"Successfully {v}");
        }

        /// <summary>
        /// Asks the user if they want to stop running the application loop.
        /// </summary>
        /// <returns>True if the user wants to leave; false if they want to stay.</returns>
        internal bool GetExitChoice()
        {
            Console.Write("Do you want to exit[y/n]:");
            string? inputExitChoice = Console.ReadLine();
            if ((string.IsNullOrEmpty(inputExitChoice) || string.IsNullOrWhiteSpace(inputExitChoice)) || (inputExitChoice.ToLower() != "y" && inputExitChoice.ToLower() != "n"))
            {
                Console.WriteLine("invalid choice");
                this.GetExitChoice();
            }

            if (inputExitChoice == "n")
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
