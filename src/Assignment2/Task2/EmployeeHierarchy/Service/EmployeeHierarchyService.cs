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

        /// <summary>Creates a manager or developer instance based on position.</summary>
        /// <param name="name">Employee name.</param>
        /// <param name="position">Position string ('manager' or 'developer').</param>
        /// <param name="salary">Employee salary.</param>
        /// <returns>The created Employee object.</returns>
        /// <exception cref="ArgumentException">Thrown if position is invalid.</exception>
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
