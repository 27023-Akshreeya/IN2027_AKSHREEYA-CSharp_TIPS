namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Represents a manager employee within the organization hierarchy.
    /// Inherits base characteristics from the <see cref="Employee"/> class.
    public class Manager : Employee
    {
        /// <summary>
        /// The fixed bonus percentage rate applied to the manager's base salary (10%).
        /// </summary>
        private const double BONUSRATE = 0.10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class with a specified name, salary, and position.
        /// </summary>
        /// <param name="name">The legal or preferred name of the manager.</param>
        /// <param name="salary">The annual or monthly base salary amount.</param>
        /// <param name="position">The specific leadership position or title assigned to the manager.</param>
        public Manager(string name, double salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// Gets the postion as manager
        /// </summary>
        /// <value> Manager
        /// </value>
        public override string Position => "Manager";

        /// <summary>
        /// Calculates the performance or annual bonus specific to a manager based on their salary.
        /// </summary>
        /// <returns>A <see cref="double"/> value representing 10% of the manager's base salary.</returns>
        public override double CalculateBonus()
        {
            return this.Salary * BONUSRATE;
        }
    }
}
