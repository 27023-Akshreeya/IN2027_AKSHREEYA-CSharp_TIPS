using System;
using EmployeeHierarchy.Model;

namespace EmployeeHierarchy.Service
{
    /// <summary>
    /// This is the class where all service operations are implemented.
    /// </summary>
    public class EmployeeHierarchyService
    {
        /// <summary>
        /// Calculates the bonus for the specified employee.
        /// </summary>
        /// <param name="employee">The employee for whom to calculate the bonus.</param>
        /// <returns>The calculated bonus amount.</returns>
        public double CalculateBonuses(Employee employee)
        {
            return employee.CalculateBonus();
        }

        /// <summary>
        /// Creates an employee instance based on the specified position.
        /// </summary>
        /// <param name="name">The employee's name.</param>
        /// <param name="position">The employee's position, used to determine the type of employee to create.</param>
        /// <param name="salary">The employee's salary.</param>
        /// <returns>An Employee object representing either a manager or a developer.</returns>
        /// <exception cref="ArgumentException">Thrown when the position is not recognized as 'manager' or 'developer'.</exception>
        public Employee CreateEmployee(
            string name,
            string position,
            double salary)
        {
            return position.ToLower() switch
            {
                "manager" => new Manager(name, salary),
                "developer" => new Developer(name, salary),
                _ => throw new ArgumentException("Invalid position")
            };
        }
    }
}
