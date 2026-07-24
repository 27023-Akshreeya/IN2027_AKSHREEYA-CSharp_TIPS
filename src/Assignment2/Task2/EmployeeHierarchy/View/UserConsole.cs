using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeHierarchy.Model;

namespace EmployeeHierarchy.View
{
    /// <summary>
    /// Provides console-based methods for interacting with users to display menus and gather employee information,
    /// including name, position, salary, and exit choices.
    /// </summary>
    public class UserConsole
    {
        private Helper _helper = new Helper();

        /// <summary>
        /// Displays the main menu for the Employee Bonus Calculator application.
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("Employee Bonus Calculator\n--------------------------------");
        }

        /// <summary>
        /// Prompts for the employee's name and returns it if valid.
        /// </summary>
        /// <returns>The validated employee name, or null if the input is invalid.</returns>
        public string? GetEmployeeName()
        {
            Console.Write("Enter Name of the employee:");
            var name = Console.ReadLine();
            if (name is null || !this._helper.IsNameValid(name))
            {
                Console.WriteLine($"Invalid Name.");
                return null;
            }

            return name;
        }

        /// <summary>
        /// Prompts for the employee's position and returns the validated position in lowercase.
        /// </summary>
        /// <returns>The validated position in lowercase, or null if the position is invalid.</returns>
        public string? GetEmployeeDescription()
        {
            Console.Write("Enter the position of the employee:");
            string? position = Console.ReadLine();
            if (position is null || !this._helper.IsPositionValid(position))
            {
                Console.WriteLine("Invalid position!");
                return null;
            }

            return position.ToLower();
        }

        /// <summary>
        /// Prompts for and retrieves a validated employee salary from user input.
        /// </summary>
        /// <returns>The entered salary as a double, or 0 if the input is invalid.</returns>
        public double GetSalary()
        {
            Console.Write("Enter the salary of the employee:");
            var input = Console.ReadLine();
            if (input is null || !this._helper.IsSalaryValid(input))
            {
                Console.WriteLine("Invalid");
                return 0;
            }

            double salary = double.Parse(input);
            return salary;
        }

        /// <summary>
        /// Prompts the user to confirm whether to exit the application.
        /// </summary>
        /// <returns>true if the user chooses to exit; otherwise, false.</returns>
        internal bool GetUserChoice()
        {
            Console.Write("Do you want to exit? [y/n]:");
            string? input = Console.ReadLine();
            if (!this._helper.IsNameValid(input))
            {
                Console.WriteLine("Invalid choice\n");
                this.GetUserChoice();
            }

            if (input is null || input.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This prints the details to user.
        /// </summary>
        /// <param name="name"> Name of the employee </param>
        /// <param name="position"> position of the employee </param>
        /// <param name="bonus"> bonus of the employee </param>
        /// <param name="salary"> Salary of the employee </param>
        internal void PrintDetailsToUser(string? name, string position, double bonus, double salary)
        {
            Console.WriteLine($"|---Bonus---|\nName:{name}\nPosition:{position}\nSalary:{salary}\nBonus:{bonus}");
        }
    }
}
