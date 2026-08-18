using System;
using ErrorHandlingTasks.Application;
using ErrorHandlingTasks.Presentation;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ExceptionService exceptionService = new ExceptionService();
            ConsoleUI consoleUI = new ConsoleUI(exceptionService);
            consoleUI.Run();
            Console.ReadLine();
        }
    }
}