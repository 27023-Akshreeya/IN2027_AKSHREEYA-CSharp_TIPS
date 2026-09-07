using System;
using EmployeeHierarchy.Helper;
using EmployeeHierarchy.Service;

namespace EmployeeHierarchy.View
{
    /// <summary>Handles console menus and collects employee input data.</summary>
    public class EmployeeHierarchyViewer
    {
        private readonly EmployeeHierarchyService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeHierarchyViewer"/> class. 
        /// Initializes the viewer with an employee data service.</summary>
        /// <param name="service">Employee data service.</param>
        public EmployeeHierarchyViewer(EmployeeHierarchyService service)
        {
            this._service = service;
        }

        /// <summary>Loops user prompts for employee details until they choose to exit.</summary>
        /// <remarks>Continues to prompt the user until they choose to exit.</remarks>
        public void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Employee Bonus Calculator\n--------------------------------");
                string name = this.GetEmployeeName();
                if (name.Equals(string.Empty))
                {
                    continue;
                }

                string position = this.GetEmployeeDescription();
                if (position.Equals(string.Empty))
                {
                    continue;
                }

                double salary = this.GetSalary();
                if (salary.Equals(0))
                {
                    continue;
                }

                var bonus = this._service.CalculateBonuses(this._service.CreateEmployee(name, position, salary));
                this.PrintDetailsToUser(name, position, bonus, salary);
                exit = this.GetUserChoice();
            }
        }

        /// <summary>
        /// Prompts for the employee's name and returns it if valid.
        /// </summary>
        /// <returns>The validated employee name, or null if the input is invalid.</returns>
        public string GetEmployeeName()
        {
            Console.Write("Enter Name of the employee:");
            string name = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsNameValid(name))
            {
                Console.WriteLine($"Invalid Name.");
            }

            return name;
        }

        /// <summary>
        /// Prompts for the employee's position and returns the validated position.
        /// </summary>
        /// <returns>The validated position in lowercase, or null if the position is invalid.</returns>
        public string GetEmployeeDescription()
        {
            Console.Write("Enter the position of the employee:");
            string position = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsPositionValid(position))
            {
                Console.WriteLine("Invalid position!");
            }

            return position.ToLower();
        }

        /// <summary>
        /// Prompts for and retrieves a validated employee salary from user input.
        /// </summary>
        /// <returns>The entered salary or 0 if the input is invalid.</returns>
        public double GetSalary()
        {
            Console.Write("Enter the salary of the employee:");
            var input = Console.ReadLine() ?? string.Empty;
            if (!Validator.IsSalaryValid(input))
            {
                Console.WriteLine("Invalid");
                return 0;
            }

            return double.Parse(input);
        }

        /// <summary>
        /// Prompts the user to confirm whether to exit the application.
        /// </summary>
        /// <returns>true if the user chooses to exit; otherwise, false.</returns>
        internal bool GetUserChoice()
        {
            for (int attempts = 0; attempts <= 3; attempts++)
            {
                Console.Write($"Attempt:{attempts}\n\nDo you want to exit? [y/n]:");
                string input = Console.ReadLine() ?? string.Empty;
                if (Validator.IsChoiceValid(input))
                {
                    return input.ToLower().Equals("y");
                }

                Console.WriteLine("Invalid choice\n");
            }

            return false;
        }

        /// <summary>
        /// This prints the details to user.
        /// </summary>
        /// <param name="name"> Name of the employee </param>
        /// <param name="position"> position of the employee </param>
        /// <param name="bonus"> bonus of the employee </param>
        /// <param name="salary"> Salary of the employee </param>
        internal void PrintDetailsToUser(string name, string position, double bonus, double salary)
        {
            Console.WriteLine($"|---Bonus---|\n\nName:{name}\nPosition:{position}\nBonus:{bonus}\nTotal Salary:{salary + bonus}");
        }
    }
}
