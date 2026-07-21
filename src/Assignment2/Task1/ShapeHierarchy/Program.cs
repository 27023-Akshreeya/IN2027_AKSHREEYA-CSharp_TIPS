using Oops_basic.View;
using ShapeHierarchy.Controller;

namespace ShapeHierarchy
{
    /// <summary>
    /// this is the main program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// the program class contains the main class.
        /// </summary>
        /// <param name="args">argument</param>
        public static void Main(string[] args)
        {
            Service service = new Service();
            service.UserOperation();
        }
    }
}