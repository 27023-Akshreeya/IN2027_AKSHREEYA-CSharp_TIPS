using System;
using ContactManager.ConsoleView;
using ContactManager.Service;

namespace ContactManager
{
    /// <summary>
    /// program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main scope
        /// </summary>
        /// <param name="args">argumenrs</param>
        public static void Main(string[] args)
        {
            UserConsole userConsole = new UserConsole();
            userConsole.Menu();
        }
    }
}