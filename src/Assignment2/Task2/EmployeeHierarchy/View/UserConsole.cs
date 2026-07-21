using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeHierarchy.Model;

namespace EmployeeHierarchy.View
{
    public class UserConsole
    {
        private Helper _helper = new Helper();

        public void DisplayMenu()
        {
            Console.WriteLine("Employee Bonus Calculator\n--------------------------------");
        }

        public string GetEmployeeName()
        {
            Console.Write("Enter Name of the employee:");
            var name = Console.ReadLine();
            if (!_helper.IsNameValid(name))
            {
                Console.WriteLine($"Invalid Name.");
                return null;
            }

            return name;
        }

        public string GetEmployeeDescription()
        {
            Console.Write("Enter the position of the employee:");
            string position = Console.ReadLine();
            if (!_helper.IsPositionValid(position))
            {
                Console.WriteLine("Invalid position!");
                return null;
            }

            return position.ToLower();
        }

        public double GetSalary()
        {
            Console.Write("Enter the salary of the employee:");
            var input = Console.ReadLine();
            if (!_helper.IsSalaryValid(input))
            {
                Console.WriteLine("Invalid");
                return 0;
            }

            double salary = Double.Parse(input);
            return salary;
        }

        internal bool GetUserChoice()
        {
            Console.Write("Do you want to exit? [y/n]:");
            string input = Console.ReadLine();
            if (!_helper.IsNameValid(input))
            {
                Console.WriteLine("Invalid choice\n");
                GetUserChoice();
            }

            if (input.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
