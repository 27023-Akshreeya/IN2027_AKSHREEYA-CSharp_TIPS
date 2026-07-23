using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Serves as the abstract base class for all employee types within the organization.
    /// Defines shared properties and forces specific bonus calculation strategies.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Gets or sets the full name of the employee.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the employee's name, or null if unassigned.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the base salary amount for the employee.
        /// </summary>
        /// <value>
        /// A <see cref="double"/> representing the raw monetary base compensation.
        /// </value>
        public double Salary { get; set; }

        /// <summary>
        /// Gets or sets the operational job position or title of the employee.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the job title, or null if unassigned.
        /// </value>
        public string? Position { get; set; }

        /// <summary>
        /// When overridden in a derived class, calculates the role-specific bonus amount.
        /// </summary>
        /// <returns>A <see cref="double"/> representing the computed financial bonus.</returns>
        public abstract double CalculateBonus();

        /// <summary>
        /// Prints the formatted details of the employee, including their calculated bonus, to the console.
        /// </summary>
        /// <param name="position">The position of the employee</param>
        public void PrintDetails(string position)
        {
            double bonus = this.CalculateBonus();
            Console.WriteLine($"|---Bonus---|\nName:{this.Name}\nPosition:{position}\nSalary:{this.Salary}\nBonus:{bonus}");
        }
    }
}
