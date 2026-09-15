namespace ShapeHierarchy.Model
{
    /// <summary>
    /// This class contains the details of rectangle, is child class from shapeinfo
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// This is the consructor of the rectangle info class.
        /// </summary>
        /// <param name="shapeName">argument : shape info</param>
        /// <param name="color">argument  : color</param>
        /// <param name="length">argument : length</param>
        /// <param name="height">argument : Height </param>
        public Rectangle(string shapeName, string color, double length, double height)
            : base(shapeName, color)
        {
            this.Length = length;
            this.Height = height;
        }

        /// <summary>
        /// Gets contains the properties of a rectangle
        /// </summary>
        /// <value>/// Contains the properties of a rectangle
        /// </value>
        public double Length { get; }

        /// <summary>
        /// Gets this states Height property
        /// </summary>
        /// <value>
        /// This states Height property
        /// </value>
        public double Height { get; }

        /// <summary>
        /// this calculates the area of a rectangle.
        /// </summary>
        /// <returns>returns area as double</returns>
        public override double CalculateArea()
        {
            if (this.Height <= 0 || this.Length <= 0)
            {
                return -1;
            }

            return this.Length * this.Height;
        }
    }
}
