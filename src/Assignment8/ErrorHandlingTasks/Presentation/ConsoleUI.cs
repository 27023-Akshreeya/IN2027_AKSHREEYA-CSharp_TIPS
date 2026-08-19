using System;
using ErrorHandlingTasks.Application;
using ErrorHandlingTasks.Domain;

namespace ErrorHandlingTasks.Presentation
{
    /// <summary>
    /// Handles user interaction for error handling tasks.
    /// </summary>
    public class ConsoleUI
    {
        private readonly ExceptionService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
        /// Initializes the console UI.
        /// </summary>
        /// <param name="service">Exception service instance.</param>
        public ConsoleUI(ExceptionService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Gets a valid numeric input from the user.
        /// </summary>
        /// <param name="userPrompt">Input prompt.</param>
        /// <returns>User-entered number.</returns>
        /// <exception cref="InvalidUserInputException">
        /// Thrown when input is invalid.
        /// </exception>
        public int GetNumericInput(string userPrompt)
        {
            Console.Write(userPrompt);
            string userInput = Console.ReadLine() ?? string.Empty;
            if (!InputValidator.IsNumberValid(userInput))
            {
                throw new InvalidUserInputException(ErrorHandlingResource.invalidInput);
            }

            return Convert.ToInt32(userInput);
        }

        /// <summary>
        /// Runs all exception handling tasks.
        /// </summary>
        public void Run()
        {
            this.ExecuteDivisionOperation();
            this.ExecuteArrayAccessOperation();
        }

        /// <summary>
        /// Executes the division operation.
        /// </summary>
        public void ExecuteDivisionOperation()
        {
            Console.WriteLine("Executing task 1: Division");
            try
            {
                int dividend = this.GetNumericInput(ErrorHandlingResource.Numerator);
                int divisor = this.GetNumericInput(ErrorHandlingResource.Denominator);
                var result = this._service.PerformDivision(dividend, divisor);
                Console.WriteLine($"Result : {result}");
            }
            catch (DivideByZeroException ex)
            {
                this.DisplayErrorMessage(ex.Message);
            }
            catch (InvalidUserInputException ex)
            {
                this.DisplayErrorMessage(ex.Message);
            }
            finally
            {
                this.DisplayMessage("Error handling in Division is done successfully!");
            }
        }

        /// <summary>
        /// Executes the array access operation.
        /// </summary>
        public void ExecuteArrayAccessOperation()
        {
            Console.WriteLine("Executing task 2: Accessing element in an array");
            try
            {
                int arraySize = this.GetNumericInput("Enter Array size:");
                int[] array = new int[arraySize];
                for (int i = 0; i < arraySize; i++)
                {
                    array[i] = this.GetNumericInput($"Enter element {i + 1}:");
                }

                int index = this.GetNumericInput("Enter the index of element you want to access:");
                int result = this._service.AccessArrayElement(index, array);
                Console.WriteLine($"Element is {result}");
            }
            catch (InvalidIndexAccessException ex)
            {
                this.DisplayErrorMessage(ex.Message);
            }
            catch (InvalidUserInputException ex)
            {
                this.DisplayErrorMessage(ex.Message);
            }
            finally
            {
                this.DisplayMessage("Error handling in accessing an array is done successfully!");
            }
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a message.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public void DisplayMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}" + "\n");
            Console.ResetColor();
        }
    }
}
