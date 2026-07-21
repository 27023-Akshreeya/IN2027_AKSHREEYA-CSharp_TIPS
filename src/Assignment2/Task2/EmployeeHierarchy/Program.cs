using EmployeeHierarchy.Controller;
using EmployeeHierarchy.View;

namespace Assignments
{
    /// <summary>
    /// This class initializes the application and starts user interactions.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that serves as the starting point of the application.
        /// </summary>
        /// <param name="args"> Command-line arguments passed to the application. </param>
        public static void Main(string[] args)
        {
            Service service = new Service();
            service.UserOperation();
        }
    }
}