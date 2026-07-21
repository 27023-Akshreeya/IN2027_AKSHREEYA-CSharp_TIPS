using ShapeHierarchy.Model;
using ShapeHierarchy.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeHierarchy.Controller
{
    /// <summary>
    /// This is service class where all control operations take place
    /// </summary>
    internal class Service
    {
        /// <summary>
        /// This creates a new object from user console class.
        /// </summary>
        private UserConsole _userConsole = new UserConsole();

        /// <summary>
        /// This is the main operation
        /// </summary>
        public void UserOperation()
        {
            bool exit = true;
            while (exit)
            {
                this._userConsole.DisplayMenu();

                string? choice = Console.ReadLine();
                if (!Helper.IsChoiceValid(choice))
                {
                    this._userConsole.UserAlert();
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        RectangleInfo rectangle = this._userConsole.GetRectangleDetails();
                        rectangle.PrintArea();
                        break;
                    case "2":
                        CircleInfo circle = this._userConsole.GetCircleDetails();
                        circle.PrintArea();
                        break;
                    case "3":
                        exit = false;
                        break;
                    default:
                        this._userConsole.UserAlert();
                        break;
                }
            }
        }
    }
}