using System;
using ShapeHierarchy.Model;
using ShapeHierarchy.Service;
using Spectre.Console;

namespace ShapeHierarchy.View
{
    /// <summary>
    /// This class is responsible for handling user interactions in the console application. It provides methods to display menus, alert users of invalid choices, and gather shape details from the user.
    /// </summary>
    public class ShapeHierarchyViewer
    {
        private readonly ShapeHierarchyService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeHierarchyViewer"/> class.
        /// </summary>
        /// <param name="service">Service used to interact with shape data.</param>
        public ShapeHierarchyViewer(ShapeHierarchyService service)
        {
            this._service = service;
        }

        /// <summary>
        /// This method displays the main menu to the user, prompting them to select a shape for area calculation or to exit the application.
        /// </summary>
        /// <returns>return user choice</returns>
        public string DisplayMenu()
        {
            var panel = new Panel(new Rows(
                new Markup("[bold blue]Main Menu[/]").Centered(),
                Text.NewLine,
                new Text("Select the shape to calculate area: \n1. Rectangle\n2. Circle\n3. Exit\n")
                .LeftJustified()))
            { Width = 60 };
            AnsiConsole.Write(panel);
            Console.Write("Enter your option:");
            string choice = Console.ReadLine() ?? string.Empty;
            if (!Helper.Validator.IsChoiceValid(choice))
            {
                return string.Empty;
            }

            return choice;
        }

        /// <summary>
        /// This is the main operation
        /// </summary>
        public void StartOperation()
        {
            bool exit = false;
            while (!exit)
            {
                var choice = this.DisplayMenu();
                switch (choice)
                {
                    case "1":
                        var rectangle = this.GetRectangleDetails();
                        if (rectangle is null)
                        {
                            continue;
                        }

                        var rectangleArea = this._service.CalculateArea(rectangle);
                        if (rectangleArea <= 0)
                        {
                            this.UserAlert();
                            continue;
                        }

                        this.PrintDetails(rectangle.ShapeName, rectangle.Color, rectangleArea);
                        break;
                    case "2":
                        var circle = this.GetCircleDetails();
                        if (circle is null)
                        {
                            continue;
                        }

                        var circleArea = this._service.CalculateArea(circle);
                        this.PrintDetails(circle.ShapeName, circle.Color, circleArea);
                        break;
                    case "3":
                        this.DisplayExitStatus();
                        exit = true;
                        break;
                    default:
                        this.UserAlert();
                        break;
                }
            }
        }

        /// <summary>
        /// This method alerts the user when they have made an invalid choice, prompting them to select a valid option from the menu.
        /// </summary>
        public void UserAlert() => AnsiConsole.Markup("[bold red]Invalid choice![/] Please select a valid option.\n\n");

        /// <summary>
        /// This method gathers details for a circle from the user, including color and radius. It validates the inputs and returns a CircleInfo object containing the shape's details.
        /// </summary>
        /// <returns>This returns an object</returns>
        public Circle GetCircleDetails()
        {
            Console.Write("Enter the color of the circle:");
            var color = Console.ReadLine() ?? string.Empty;
            if (!Helper.Validator.IsColorValid(color))
            {
                AnsiConsole.Markup("[bold red]Invalid color![/] Please enter a valid color.\n\n");
                return null;
            }

            Console.Write("Enter the radius of the circle:");
            var radiusInput = Console.ReadLine() ?? string.Empty;
            if (!Helper.Validator.IsDimensionValid(radiusInput))
            {
                AnsiConsole.Markup("[bold red]Invalid radius![/] Please enter a positive number.\n\n");
                return null;
            }

            double radius = Convert.ToDouble(radiusInput);
            var circleDetails = new Circle("Circle", color, radius);
            return circleDetails;
        }

        /// <summary>
        /// This method gathers details for a rectangle from the user, including color, length, and height. It validates the inputs and returns a RectangleInfo object containing the shape's details.
        /// </summary>
        /// <returns>This returns the rectangle object</returns>
        public Rectangle GetRectangleDetails()
        {
            Console.Write("Enter the color of the rectangle:");
            var color = Console.ReadLine();
            if (!Helper.Validator.IsColorValid(color))
            {
                AnsiConsole.Markup("[bold red]Invalid color![/] Please enter a valid color.\n\n");
                return null;
            }

            Console.Write("Enter the length of the rectangle:");

            var lengthInput = Console.ReadLine();
            if (!Helper.Validator.IsDimensionValid(lengthInput))
            {
                AnsiConsole.Markup("[bold red]Invalid length![/] Please enter a positive number.\n\n");
                return null;
            }

            double length = Convert.ToDouble(lengthInput);

            Console.Write("Enter the height of the rectangle:");
            var heightInput = Console.ReadLine();
            if (!Helper.Validator.IsDimensionValid(heightInput))
            {
                AnsiConsole.Markup("[bold red]Invalid height![/] Please enter a positive number.\n\n");
                return null;
            }

            double height = Convert.ToDouble(heightInput);

            var rectangleDetails = new Rectangle("Rectangle", color, length, height);
            return rectangleDetails;
        }

        /// <summary>
        /// This method prints the details of the shape.
        /// </summary>
        /// <param name="shapeName">name of the shape</param>
        /// <param name="color">color of the shape</param>
        /// <param name="area">area of the shape</param>
        public void PrintDetails(string shapeName, string color, double area)
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
        public void DisplayExitStatus()
        {
            AnsiConsole.Markup("[bold red]EXITING..[/] [grey]Press any key to exit[/]");
            Console.ReadKey();
        }
    }
}