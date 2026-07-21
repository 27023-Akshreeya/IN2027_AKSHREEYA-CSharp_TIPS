using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeHierarchy.Model;
using EmployeeHierarchy.View;

namespace EmployeeHierarchy.Controller
{
    public class Service
    {
        private UserConsole _userConsole = new UserConsole();

        public void UserOperation()
        {
            bool exit = false;
            while (!exit)
            {
                _userConsole.DisplayMenu();
                string name = _userConsole.GetEmployeeName();
                if (name == null)
                {
                    exit = _userConsole.GetUserChoice();
                    continue;
                }

                string position = _userConsole.GetEmployeeDescription();
                if (position == null)
                {
                    exit = _userConsole.GetUserChoice();
                    continue;
                }

                double salary = _userConsole.GetSalary();
                if (salary <= 0)
                {
                    exit = _userConsole.GetUserChoice();
                    continue;
                }

                if (position == "manager")
                {
                    Manager manager = new Manager(name, salary, position);
                    manager.PrintDetails();
                }
                else
                {
                    Developer developer = new Developer(name, salary, position);
                    developer.PrintDetails();
                }

                exit = _userConsole.GetUserChoice();
            }
        }
    }
}
