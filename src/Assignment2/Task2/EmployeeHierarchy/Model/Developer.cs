using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy.Model
{
    public class Developer : Employee
    {
        private const double V = 0.15;

        public Developer(string name, double salary, string position)
        {
            Name = name;
            Salary = salary;
            Position = position;
        }

        public string? Position { get; set; }

        public override double CalculateBonus()
        {
            return Salary * V;
        }
    }
}
