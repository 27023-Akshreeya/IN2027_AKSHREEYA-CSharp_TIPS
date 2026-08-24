using System;
using ShapeHierarchy.Service;
using ShapeHierarchy.View;

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
            try
            {
                var service = new ShapeHierarchyService();
                var viewer = new ShapeHierarchyViewer(service);
                viewer.StartOperation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The application experienced an unexpected error and the application will be closed!\r\nThe error message: " + ex.Message);
            }
        }
    }
}