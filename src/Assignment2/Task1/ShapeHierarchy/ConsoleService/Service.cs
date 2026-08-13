using System;
using ShapeHierarchy.View;

namespace ShapeHierarchy.ConsoleService
{
    /// <summary>
    /// This is service class where all control operations take place
    /// </summary>
    internal class Service
    {
        /// <summary>
        /// This creates a new object from user console class.
        /// </summary>
        private ShapeHierarchyViewer _userConsole = new ShapeHierarchyViewer();

        /// <summary>
        /// This is the main operation
        /// </summary>
        internal void StartOperation()
        {
            bool exit = false;
            while (!exit)
            {
                this._userConsole.DisplayMenu();

                string choice = Console.ReadLine();
                if (choice is null || !Helper.Validator.IsChoiceValid(choice))
                {
                    this._userConsole.UserAlert();
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        var rectangle = this._userConsole.GetRectangleDetails();
                        if (rectangle is null)
                        {
                            continue;
                        }

                        double rectangeArea = rectangle.CalculateArea();
                        this._userConsole.PrintDetails(rectangle.ShapeName, rectangle.Color, rectangeArea);
                        break;
                    case "2":
                        var circle = this._userConsole.GetCircleDetails();
                        if (circle is null)
                        {
                            continue;
                        }

                        double circleArea = circle.CalculateArea();
                        this._userConsole.PrintDetails(circle.ShapeName, circle.Color, circleArea);
                        break;
                    case "3":
                        this._userConsole.DisplayExitStatus();
                        exit = true;
                        break;
                    default:
                        this._userConsole.UserAlert();
                        break;
                }
            }
        }
    }
}