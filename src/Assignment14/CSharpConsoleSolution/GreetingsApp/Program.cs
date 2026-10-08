using MathApp;

namespace GreetingsApp
{
    /// <summary>
    /// Contains the application's entry point and coordinates greeting display and math operations.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            DisplayGreeting();
            MathApp.Program.Main();
        }

        private static void DisplayGreeting()
        {
            Console.WriteLine("Greeting from GreetingsApp!");
        }
    }
}