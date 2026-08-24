namespace ShapeHierarchy.Model
{
    /// <summary>
    /// Base class for shapes that forces derived classes to calculate their own area.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class with the specified name and color.
        /// </summary>
        /// <param name="shapeName">The name of the shape.</param>
        /// <param name="color">The color of the shape.</param>
        protected Shape(string shapeName, string color)
        {
            this.ShapeName = shapeName;
            this.Color = color;
        }

        /// <summary>
        /// Gets this contains the fields and methods of the parent class.
        /// </summary>
        /// <value>/// This contains the fields and methods of the parent class.
        /// </value>
        public string ShapeName { get; }

        /// <summary>
        /// Gets this contains color as property
        /// </summary>
        /// <value> ///This contains color as property
        /// </value>
        public string Color { get; }

        /// <summary>
        /// This is a abstract method to calculate area.
        /// </summary>
        /// <returns>returns a double</returns>
        public abstract double CalculateArea();
    }
}