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
        /// <returns> User-entered number.</returns>
        /// <exception cref="InvalidUserInputException">
        /// Thrown when input is invalid.
        /// </exception>
        public int GetNumericInput(string userPrompt)
        {
            Console.Write(userPrompt);
            string userInput = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(userInput, out int inputNumeric))
            {
                throw new InvalidUserInputException(ErrorHandlingResource.invalidInput);
            }

            return inputNumeric;
        }

        /// <summary>
        /// Runs all exception handling tasks.
        /// </summary>
        public void Run()
        {
            this.ExecuteDivisionOperation();
            this.ExecuteArrayAccessOperation();
            this.ThrowUnhandledException();
        }

        private void ThrowUnhandledException()
        {
            this._service.UnhandledException();
        }

        /// <summary>
        /// Executes the division operation.
        /// </summary>
        private void ExecuteDivisionOperation()
        {
            this.DisplayMessage("Executing task 1: Division", ConsoleColor.White);
            try
            {
                int dividend = this.GetNumericInput(ErrorHandlingResource.Numerator);
                int divisor = this.GetNumericInput(ErrorHandlingResource.Denominator);
                var result = this._service.PerformDivision(dividend, divisor);
                this.DisplayMessage($"Result : {result}", ConsoleColor.Green);
            }
            catch (DivideByZeroException ex)
            {
                this.DisplayMessage(ex.Message, ConsoleColor.Red);
            }
            catch (InvalidUserInputException ex)
            {
                this.DisplayMessage(ex.Message, ConsoleColor.Red);
            }
            finally
            {
                this.DisplayMessage("Division Operation Completed", ConsoleColor.Blue);
            }
        }

        /// <summary>
        /// Executes the array access operation.
        /// </summary>
        private void ExecuteArrayAccessOperation()
        {
            this.DisplayMessage("Executing task 2: Accessing element in an array", ConsoleColor.White);
            try
            {
                int arraySize = this.GetNumericInput("Enter Array size:");
                if (arraySize == 0)
                {
                    this.DisplayMessage("Array size cant be zero!", ConsoleColor.Red);
                    return;
                }

                int[] array = new int[arraySize];
                for (int arrayIndex = 0; arrayIndex < arraySize; arrayIndex++)
                {
                    array[arrayIndex] = this.GetNumericInput($"Enter element {arrayIndex + 1}:");
                }

                int index = this.GetNumericInput("Enter the index of element you want to access:");
                int result = this._service.AccessArrayElement(index, array);
                this.DisplayMessage($"Element is {result}", ConsoleColor.Green);
            }
            catch (InvalidIndexAccessException ex)
            {
                this.DisplayMessage(ex.Message, ConsoleColor.Red);
                if (ex.InnerException != null)
                {
                    this.DisplayMessage($"Exception : {ex.InnerException.Message}", ConsoleColor.Red);
                }
            }
            catch (InvalidUserInputException ex)
            {
                this.DisplayMessage(ex.Message, ConsoleColor.Red);
            }
            finally
            {
                this.DisplayMessage("Array access operation completed", ConsoleColor.Blue);
            }
        }

        /// <summary>
        /// Displays a message.
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="color">Color the message is to be displayed</param>
        private void DisplayMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{message}" + "\n");
            Console.ResetColor();
        }
    }
}
