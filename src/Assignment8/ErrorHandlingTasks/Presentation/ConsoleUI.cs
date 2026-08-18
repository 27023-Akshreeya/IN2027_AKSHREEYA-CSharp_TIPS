using System;
using ErrorHandlingTasks.Application;
using ErrorHandlingTasks.Domain;

namespace ErrorHandlingTasks.Presentation
{
    public class ConsoleUI
    {
        private readonly ExceptionService _service;

        public ConsoleUI(ExceptionService service)
        {
            this._service = service;
        }

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

        public void Run()
        {
            this.ExecuteDivisionOperation();
            this.ExecuteArrayAccessOperation();
        }

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
            catch (Exception ex)
            {
                this.DisplayErrorMessage(ex.Message);
            }
            finally
            {
                this.DisplayMessage("Error handling in Division is done successfully!");
            }
        }

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
            catch (Exception ex)
            {
                this.DisplayErrorMessage(ex.Message);
            }
            finally
            {
                this.DisplayMessage("Error handling in accessing an array is done successfully!");
            }
        }

        public void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }

        public void DisplayMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}" + "\n");
            Console.ResetColor();
        }
    }
}
