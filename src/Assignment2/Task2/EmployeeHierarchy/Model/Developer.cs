namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Represents a developer <see cref="Employee"/> within the organization hierarchy.
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// The fixed bonus percentage rate applied to the developer's base salary (15%).
        /// </summary>
        private const double BonusRate = 0.15;

        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class with a specified name, salary, and position.
        /// </summary>
        /// <param name="name">The legal or preferred name of the developer.</param>
        /// <param name="salary">The annual or monthly base salary amount.</param>
        public Developer(string name, double salary)
            : base(name, salary)
        {
        }

        /// <summary>
        /// Gets the specific technical role, level, or title of the developer.
        /// </summary>
        /// <value>
        /// The specific job title or technical role assigned to the developer.
        /// </value>
        public override string Position => "Developer";

        /// <summary>
        /// Calculates the performance or annual bonus specific to a developer based on their salary.
        /// </summary>
        /// <returns>A <see cref="double"/> value representing 15% of the developer's base salary.</returns>
        public override double CalculateBonus()
        {
            return this.Salary * BonusRate;
        }
    }
}
