namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Represents a manager <see cref="Employee"/> within the organization hierarchy.
    public class Manager : Employee
    {
        /// <summary>
        /// The fixed bonus percentage rate applied to the manager's base salary (10%).
        /// </summary>
        private const double BONUSRATE = 0.10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class with a specified name, salary, and position.
        /// </summary>
        /// <param name="name">The name of the manager.</param>
        /// <param name="salary">The monthly salary amount.</param>
        /// <param name="position">The specific position assigned.</param>
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
        /// Calculates the bonus based on their salary.
        /// </summary>
        /// <returns>A <see cref="double"/> value representing 10% of the manager's base salary.</returns>
        public override double CalculateBonus()
        {
            return this.Salary * BONUSRATE;
        }
    }
}
