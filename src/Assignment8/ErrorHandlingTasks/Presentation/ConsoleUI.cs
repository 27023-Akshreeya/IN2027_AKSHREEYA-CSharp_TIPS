using System;
using ErrorHandlingTasks.Application;

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
                throw new FormatException(ErrorHandlingResource.invalidInput);
            }

            return Convert.ToInt32(userInput);
        }

        public void Run()
        {
            this.ExecuteDivisionOperation();
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
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Error handling in Division is done successfully!");
            }
        }
    }
}
