using System;
using CalculatorApplication.Application;
using CalculatorApplication.Domain;

namespace CalculatorApplication.Presentation
{
    /// <summary>
    /// Handles user interface interactions and program loop execution.
    /// </summary>
    public class ConsoleUI
    {
        private readonly CalculatorService _calculatorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
        /// </summary>
        /// <param name="calculatorService">The service used to compute operations.</param>
        public ConsoleUI(CalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        /// <summary>
        /// Runs the main interactive menu loop for the application.
        /// </summary>
        public void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Select an operation:\n1. Add\n2. Subtract\n3. Multiply\n4. Divide");
                string choice = this.GetUserInputWithAttempts("Enter your choice:", validator => validator.Equals("1") || validator.Equals("2") || validator.Equals("3") || validator.Equals("4"), "Invalid Choice!");
                if (string.IsNullOrEmpty(choice))
                {
                    this.DisplayMessage("No valid choice entered. Exiting.", ConsoleColor.Red);
                    return;
                }

                switch ((CalculatorOperation)int.Parse(choice))
                {
                    case CalculatorOperation.Add:
                        this.DisplayMessage("Addition Operation", ConsoleColor.Green);
                        this.PerformOperation(CalculatorOperation.Add);
                        break;
                    case CalculatorOperation.Subtract:
                        this.DisplayMessage("Subtaction Operation", ConsoleColor.Green);
                        this.PerformOperation(CalculatorOperation.Subtract);
                        break;
                    case CalculatorOperation.Multiply:
                        this.DisplayMessage("Muplication Operation", ConsoleColor.Green);
                        this.PerformOperation(CalculatorOperation.Multiply);
                        break;
                    case CalculatorOperation.Divide:
                        this.DisplayMessage("Division Operation", ConsoleColor.Green);
                        this.PerformOperation(CalculatorOperation.Divide);
                        break;
                    default:
                        this.DisplayMessage("Invalid operation selected.", ConsoleColor.Red);
                        break;
                }

                exit = this.GetUserInputWithAttempts("Do you want to exit? (y/n):", input => input.ToLower().Equals("y") || input.ToLower().Equals("n"), "Invalid input! Please enter 'y' or 'n'.").ToLower().Equals("y");
                Console.Clear();
            }
        }

        /// <summary>
        /// Requests numbers from the user and executes the calculation.
        /// </summary>
        /// <param name="operation">The operation type to execute.</param>
        private void PerformOperation(CalculatorOperation operation)
        {
            string firstInput = this.GetUserInputWithAttempts("Enter the first number:", Validator.IsInputValid, "Invalid number!");
            string secondInput = this.GetUserInputWithAttempts("Enter the second number:", Validator.IsInputValid, "Invalid number!");
            if (string.IsNullOrEmpty(firstInput) || string.IsNullOrEmpty(secondInput))
            {
                this.DisplayMessage("Invalid inputs. Exiting.", ConsoleColor.Red);
                return;
            }

            var result = this._calculatorService.Calculator(operation, int.Parse(firstInput), int.Parse(secondInput));
            if (result.IsSuccess)
            {
                this.DisplayMessage($"Result: {result.Result}", ConsoleColor.Green);
            }
            else
            {
                this.DisplayMessage($"Error: {result.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Prompts for console input with a 3-attempt limit and validation logic.
        /// </summary>
        /// <param name="message">The input prompt text.</param>
        /// <param name="validator">The validation logic wrapper.</param>
        /// <param name="invalidMessage">The message to display upon validation failure.</param>
        /// <returns>The verified user input, or an empty string if all attempts fail.</returns>
        private string GetUserInputWithAttempts(string message, InputValidator validator, string invalidMessage)
        {
            for (int attempts = 3; attempts > 0; attempts--)
            {
                Console.Write($"Attemps remaining: {attempts}\n{message}");
                string input = Console.ReadLine() ?? string.Empty;
                if (validator(input))
                {
                    return input;
                }

                this.DisplayMessage(invalidMessage, ConsoleColor.Red);
            }

            return string.Empty;
        }

        /// <summary>
        /// Outputs text to the console with specified foreground coloring.
        /// </summary>
        /// <param name="message">The text string to render.</param>
        /// <param name="color">The text color to use.</param>
        private void DisplayMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
