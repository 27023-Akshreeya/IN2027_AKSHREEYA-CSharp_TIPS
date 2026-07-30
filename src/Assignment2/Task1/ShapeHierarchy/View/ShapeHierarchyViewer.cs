using ShapeHierarchy.Model;

namespace ShapeHierarchy.View
{
    /// <summary>
    /// This class is responsible for handling user interactions in the console application. It provides methods to display menus, alert users of invalid choices, and gather shape details from the user.
    /// </summary>
    public class ShapeHierarchyViewer
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

            double radius = Convert.ToDouble(radiusInput);
            var shapeInfo = new Circle("Circle", color, radius);
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

            double length = Convert.ToDouble(lengthInput);

            Console.Write("Enter the height of the rectangle:");
            var heightInput = Console.ReadLine();
            if (!Helper.Validater.IsDimensionValid(heightInput))
            {
                Console.WriteLine("Invalid height. Please enter a positive number.\n");
                return this.GetRectangleDetails();
            }

            double height = Convert.ToDouble(heightInput);

            var shapeInfo = new Rectangle("Rectangle", color, length, height);
            return shapeInfo;
        }

        /// <summary>
        /// This method prints the details of the shape.
        /// </summary>
        /// <param name="shapeName">name of the shape</param>
        /// <param name="color">color of the shape</param>
        /// <param name="area">area of the shape</param>
        internal void PrintDetails(string? shapeName, string? color, double area)
        {
            Console.WriteLine($"\nThe color of the {shapeName}: {color}\nThe area of the {shapeName}: {area}");
        }
    }
}