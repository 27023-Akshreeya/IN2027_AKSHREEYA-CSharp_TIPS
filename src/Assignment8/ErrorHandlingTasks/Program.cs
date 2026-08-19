using System;
using ErrorHandlingTasks.Application;
using ErrorHandlingTasks.Presentation;

namespace Assignments
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            var exceptionService = new ExceptionService();
            var consoleUI = new ConsoleUI(exceptionService);
            consoleUI.Run();
            Console.ReadLine();
        }

        /// <summary>
        /// Handles unhandled exceptions.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Exception event data.</param>
        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                Console.WriteLine($"error: {exception.Message}");
                Console.WriteLine(exception.StackTrace);
            }
        }
    }
}