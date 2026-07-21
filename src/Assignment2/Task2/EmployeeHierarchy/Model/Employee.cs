using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy.Model
{
    public abstract class Employee
    {
        public string? Name { get; set; }

        public double Salary { get; set; }

        public string? Position { get; set; }

        public abstract double CalculateBonus();

        public void PrintDetails()
        {
            double bonus = CalculateBonus();
            Console.WriteLine($"|---Bonus---|\nName:{Name}\nPosition:{Position}\nSalary:{Salary}\nBonus:{bonus}");
        }
    }
}
