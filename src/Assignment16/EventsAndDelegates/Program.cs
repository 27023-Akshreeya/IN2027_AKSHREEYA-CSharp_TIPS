using System;

namespace EventsAndDelegates
{ /// <summary>
  /// Core application execution entry point.
  /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the console application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                var notifier = new Notifier();
                notifier.OnAction += PrintMessageToConsole;
                notifier.TriggerAction("Hello world");
                notifier.OnAction -= PrintMessageToConsole;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Writes the received notification message directly to the console window.
        /// </summary>
        /// <param name="message">The string content to output.</param>
        public static void PrintMessageToConsole(string message)
        {
            Console.WriteLine($"The received message is: {message}");
        }
    }
}
