using System;
using CalculatorApplication.Application;
using CalculatorApplication.Presentation;

namespace Assignments
{
    /// <summary>
    /// The main entry point class for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Orchestrates application startup and initialization.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        internal static void Main(string[] args)
        {
            try
            {
                var calculatorService = new CalculatorService();
                var consoleUI = new ConsoleUI(calculatorService);
                consoleUI.DisplayMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
