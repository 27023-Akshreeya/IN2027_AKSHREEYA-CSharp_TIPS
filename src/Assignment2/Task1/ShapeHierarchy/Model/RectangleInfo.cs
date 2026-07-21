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
    public class RectangleInfo : ShapeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleInfo"/> class.
        /// This is the consructor of the rectangle info class.
        /// </summary>
        /// <param name="shapeName">argument : shape info</param>
        /// <param name="color">argument  : color</param>
        /// <param name="length">argument : length</param>
        /// <param name="width">argument : width </param>
        public RectangleInfo(string shapeName, string color, double length, double width)
        {
            this.ShapeName = shapeName;
            this.Color = color;
            this.Length = length;
            this.Width = width;
        }

        /// <summary>
        /// Gets or sets contains the properties of a rectangle
        /// </summary>
        /// <value>/// Contains the properties of a rectangle
        /// </value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets this states width propertyu
        /// </summary>
        /// <value>
        /// This states width property
        /// </value>
        public double Width { get; set; }

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
