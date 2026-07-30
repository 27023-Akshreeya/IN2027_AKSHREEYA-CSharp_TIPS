using ShapeHierarchy.View;

namespace ShapeHierarchy.Model
{
    /// <summary>
    /// This abstract class serves as a base for different shape types, providing common properties and methods for calculating and printing the area of shapes. It defines an abstract method for area calculation that must be implemented by derived classes.
    /// </summary>
    public abstract class Shape
    {
        private ShapeHierarchyViewer _userConsole = new ShapeHierarchyViewer();

        /// <summary>
        /// Gets or sets this contains the fields and methods of the parent class.
        /// </summary>
        /// <value>/// This contains the fields and methods of the parent class.
        /// </value>
        public string? ShapeName { get; set; }

        /// <summary>
        /// Gets or sets this contains color as property
        /// </summary>
        /// <value> ///This contains color as property
        /// </value>
        public string? Color { get; set; }

        /// <summary>
        /// This is a abstract method to calculate area.
        /// </summary>
        /// <returns>returns a double</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// This is method prints the details of the shape.
        /// </summary>
        public void PrintArea()
        {
            double area = this.CalculateArea();
            this._userConsole.PrintDetails(this.ShapeName, this.Color, area);
        }
    }
}