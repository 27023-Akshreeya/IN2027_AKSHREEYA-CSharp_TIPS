using System;
using ContactManager.Service;
using ContactManager.View;

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