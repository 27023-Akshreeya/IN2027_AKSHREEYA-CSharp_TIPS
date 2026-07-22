using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ShapeHierarchy.Helper;
using ShapeHierarchy.Model;

namespace ShapeHierarchy.View
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
            Console.WriteLine("Invalid choice. Please select a valid option.\n");
        }

        /// <summary>
        /// This method gathers details for a circle from the user, including color and radius. It validates the inputs and returns a CircleInfo object containing the shape's details.
        /// </summary>
        /// <returns>This returns an object</returns>
        public Circle GetCircleDetails()
        {
            Console.Write("Enter the color of the circle:");
            var color = Console.ReadLine();
            if (color is null || !Helper.Validater.IsColorValid(color))
            {
                Console.WriteLine("Invalid color. Please enter a valid color.\n");
                return this.GetCircleDetails();
            }

            Console.Write("Enter the radius of the circle:");
            var radiusInput = Console.ReadLine();
            if (!Helper.Validater.IsDimensionValid(radiusInput))
            {
                Console.WriteLine("Invalid radius. Please enter a positive number.\n");
                return this.GetCircleDetails();
            }

            int radius = (int)Convert.ToDouble(radiusInput);
            Circle shapeInfo = new Circle("Circle", color, radius);
            return shapeInfo;
        }

        /// <summary>
        /// This method gathers details for a rectangle from the user, including color, length, and height. It validates the inputs and returns a RectangleInfo object containing the shape's details.
        /// </summary>
        /// <returns>This returns the rectangle object</returns>
        public Rectangle GetRectangleDetails()
        {
            Console.Write("Enter the color of the rectangle:");
            var color = Console.ReadLine();
            if (color is null || !Helper.Validater.IsColorValid(color))
            {
                Console.WriteLine("Invalid color. Please enter a valid color.\n");
                return this.GetRectangleDetails();
            }

            Console.Write("Enter the length of the rectangle:");

            var lengthInput = Console.ReadLine();
            if (!Helper.Validater.IsDimensionValid(lengthInput))
            {
                Console.WriteLine("Invalid length. Please enter a positive number.\n");
                return this.GetRectangleDetails();
            }

            int length = (int)Convert.ToDouble(lengthInput);

            Console.Write("Enter the height of the rectangle:");
            var heightInput = Console.ReadLine();
            if (!Helper.Validater.IsDimensionValid(heightInput))
            {
                Console.WriteLine("Invalid height. Please enter a positive number.\n");
                return this.GetRectangleDetails();
            }

            int height = (int)Convert.ToDouble(heightInput);

            Rectangle shapeInfo = new Rectangle("Rectangle", color, length, height);
            return shapeInfo;
        }
    }
}