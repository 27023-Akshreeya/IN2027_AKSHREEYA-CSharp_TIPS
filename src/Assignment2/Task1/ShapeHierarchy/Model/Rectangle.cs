using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="width">argument : width </param>
        public Rectangle(string shapeName, string color, double length, double width)
        {
            this.ShapeName = shapeName;
            this.Color = color;
            this.Length = length;
            this.Width = width;
        }

        /// <summary>
        /// Gets contains the properties of a rectangle
        /// </summary>
        /// <value>/// Contains the properties of a rectangle
        /// </value>
        public double Length { get; }

        /// <summary>
        /// Gets this states width property
        /// </summary>
        /// <value>
        /// This states width property
        /// </value>
        public double Width { get; }

        /// <summary>
        /// this calculates the area of a rectangle.
        /// </summary>
        /// <returns>returns area as double</returns>
        public override double CalculateArea()
        {
            return this.Length * this.Width;
        }
    }
}
