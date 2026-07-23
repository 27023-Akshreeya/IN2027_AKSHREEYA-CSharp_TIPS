using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeHierarchy.Model;
using EmployeeHierarchy.View;

namespace EmployeeHierarchy.ConsoleService
{
    /// <summary>
    /// This is the class where all service operations are implemented.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// new object is created for user console.
        /// </summary>
        private UserConsole _userConsole = new UserConsole();

        /// <summary>
        /// Handles user operations for employee management, including input for employee name, position, and salary.
        /// </summary>
        /// <remarks>Continues to prompt the user until they choose to exit.</remarks>
        public void UserOperation()
        {
            bool exit = false;
            while (!exit)
            {
                this._userConsole.DisplayMenu();
                string? name = this._userConsole.GetEmployeeName();
                if (name == null)
                {
                    exit = this._userConsole.GetUserChoice();
                    continue;
                }

                string? position = this._userConsole.GetEmployeeDescription();
                if (position == null)
                {
                    exit = this._userConsole.GetUserChoice();
                    continue;
                }

                double salary = this._userConsole.GetSalary();
                if (salary <= 0)
                {
                    exit = this._userConsole.GetUserChoice();
                    continue;
                }

                if (position == "manager")
                {
                    Manager manager = new Manager(name, salary, position);
                    manager.PrintDetails("manager");
                }
                else
                {
                    Developer developer = new Developer(name, salary, position);
                    developer.PrintDetails("developer");
                }

                exit = this._userConsole.GetUserChoice();
            }
        }
    }
}
