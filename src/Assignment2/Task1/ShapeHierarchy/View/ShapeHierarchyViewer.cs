using ShapeHierarchy.Model;
using Spectre.Console;

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
            var panel = new Panel(new Rows(
                new Markup("[bold blue]Main Menu[/]").Centered(),
                Text.NewLine,
                new Text("Select the shape to calculate area: \n1. Rectangle\n2. Circle\n3. Exit\n")
                .LeftJustified()))
            { Width = 60 };
            AnsiConsole.Write(panel);
            Console.Write("Enter your option:");
        }

        /// <summary>
        /// This method alerts the user when they have made an invalid choice, prompting them to select a valid option from the menu.
        /// </summary>
        public void UserAlert()
        {
            AnsiConsole.Markup("[bold red]Invalid choice![/] Please select a valid option.\n\n");
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
                AnsiConsole.Markup("[bold red]Invalid color![/] Please enter a valid color.\n\n");
                return this.GetCircleDetails();
            }

            Console.Write("Enter the radius of the circle:");
            var radiusInput = Console.ReadLine();
            if (!Helper.Validater.IsDimensionValid(radiusInput))
            {
                AnsiConsole.Markup("[bold red]Invalid radius![/] Please enter a positive number.\n\n");
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
                AnsiConsole.Markup("[bold red]Invalid color![/] Please enter a valid color.\n\n");
                return this.GetRectangleDetails();
            }

            Console.Write("Enter the length of the rectangle:");

            var lengthInput = Console.ReadLine();
            if (!Helper.Validater.IsDimensionValid(lengthInput))
            {
                AnsiConsole.Markup("[bold red]Invalid length![/] Please enter a positive number.\n\n");
                return this.GetRectangleDetails();
            }

            double length = Convert.ToDouble(lengthInput);

            Console.Write("Enter the height of the rectangle:");
            var heightInput = Console.ReadLine();
            if (!Helper.Validater.IsDimensionValid(heightInput))
            {
                AnsiConsole.Markup("[bold red]Invalid height![/] Please enter a positive number.\n\n");
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
            string inputColor = (color ?? "white").ToLower();
            var table = new Table();
            table.AddColumn("Shape name", col => col.Centered());
            table.AddColumn("Shape details", col => col.Centered());

            table.AddRow($"{shapeName}", $"Color : [{inputColor}]{color}[/]\n Area : {area}");
            AnsiConsole.Write(table);
        }

        /// <summary>
        /// This displays the exiting status
        /// </summary>
        internal void DisplayExitStatus()
        {
            AnsiConsole.Markup("[bold red]EXITING..[/] [grey]Press any key to exit[/]");
            Console.ReadKey();
        }
    }
}