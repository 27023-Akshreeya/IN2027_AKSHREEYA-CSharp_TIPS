using System;
using ValueAndReferenceTypes.Application;
using ValueAndReferenceTypes.Presentation;

namespace Assignments
{
    /// <summary>
    /// Application entry point for the value and reference types demonstration.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Instantiates application modules and begins the user interface execution loop.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var service = new ValueAndReferenceTypeService();
            var viewer = new ConsoleUI(service);
            viewer.Execute();
        }
    }
}
