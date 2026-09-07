namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Abstract employee base class enforcing custom bonus calculations.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class
        /// with the specified employee name and salary.
        /// </summary>
        /// <param name="name">
        /// The name of the employee.
        /// </param>
        /// <param name="salary">
        /// The base salary of the employee.
        /// </param>
        protected Employee(string name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Gets the full name of the employee.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the employee's name, or null if unassigned.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the base salary amount for the employee.
        /// </summary>
        /// <value>
        /// A <see cref="double"/> representing the raw monetary base compensation.
        /// </value>
        public double Salary { get; }

        /// <summary>
        /// Gets the operational job position or title of the employee.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the job title, or null if unassigned.
        /// </value>
        public abstract string Position { get; }

        /// <summary>
        /// When overridden in a derived class, calculates the role-specific bonus amount.
        /// </summary>
        /// <returns>A <see cref="double"/> representing the computed financial bonus.</returns>
        public abstract double CalculateBonus();
    }
}
