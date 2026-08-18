using System;
using ErrorHandlingTasks.Application;
using ErrorHandlingTasks.Presentation;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            var exceptionService = new ExceptionService();
            var consoleUI = new ConsoleUI(exceptionService);
            consoleUI.Run();
            Console.ReadLine();
        }

        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}