using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Oops_basic.Model;
using ShapeHierarchy.Model;

namespace Oops_basic.View
{
    /// <summary>
    /// This class is responsible for handling user interactions in the console application. It provides methods to display menus, alert users of invalid choices, and gather shape details from the user.
    /// </summary>
    public class UserConsole
    {
        /// <summary>
        /// This method displays the main menu to the user, prompting them to select a shape for area calculation or to exit the application.
        /// </summary>
        public void DisplayMenu()
        {
            Console.Write("Select the shape to calculate area: \n1. Rectangle\n2. Circle\n3. Exit\nEnter you option:");
        }

        /// <summary>
        /// This method alerts the user when they have made an invalid choice, prompting them to select a valid option from the menu.
        /// </summary>
        public void UserAlert()
        {
            Console.WriteLine("Invalid choice. Please select a valid option.");
        }

        /// <summary>
        /// This method gathers details for a circle from the user, including color and radius. It validates the inputs and returns a CircleInfo object containing the shape's details.
        /// </summary>
        /// <returns>This returns an object</returns>
        public CircleInfo GetCircleDetails()
        {
            Console.Write("Enter the color of the circle:");
            var color = Console.ReadLine();
            if (!Helper.IsColorValid(color))
            {
                Console.WriteLine("Invalid color. Please enter a valid color.");
                return GetCircleDetails();
            }

            Console.Write("Enter the radius of the circle:");
            var radiusInput = Console.ReadLine();
            if (!Helper.IsDimensionValid(radiusInput))
            {
                Console.WriteLine("Invalid radius. Please enter a positive number.");
                return GetCircleDetails();
            }

            int radius = (int)Convert.ToDouble(radiusInput);
            CircleInfo shapeInfo = new CircleInfo("Circle", color, radius);
            return shapeInfo;
        }

        /// <summary>
        /// This method gathers details for a rectangle from the user, including color, length, and height. It validates the inputs and returns a RectangleInfo object containing the shape's details.
        /// </summary>
        /// <returns>This returns the rectangle object</returns>
        public RectangleInfo GetRectangleDetails()
        {
            Console.Write("Enter the color of the rectangle:");
            var color = Console.ReadLine();
            if (!Helper.IsColorValid(color))
            {
                Console.WriteLine("Invalid color. Please enter a valid color.");
                return GetRectangleDetails();
            }

            Console.Write("Enter the length of the rectangle:");

            var lengthInput = Console.ReadLine();
            if (!Helper.IsDimensionValid(lengthInput))
            {
                Console.WriteLine("Invalid length. Please enter a positive number.");
                return GetRectangleDetails();
            }

            int length = (int)Convert.ToDouble(lengthInput);

            Console.Write("Enter the height of the rectangle:");
            var heightInput = Console.ReadLine();
            if (!Helper.IsDimensionValid(heightInput))
            {
                Console.WriteLine("Invalid height. Please enter a positive number.");
                return GetRectangleDetails();
            }

            int height = (int)Convert.ToDouble(heightInput);

            RectangleInfo shapeInfo = new RectangleInfo("Rectangle", color, length, height);
            return shapeInfo;
        }
    }
}