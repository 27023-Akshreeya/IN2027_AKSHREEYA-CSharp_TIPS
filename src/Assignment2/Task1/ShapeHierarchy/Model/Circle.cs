using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHierarchy.Model
{
    /// <summary>
    /// This is a child class containing the circles details
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// This is the constructor to get the circles details
        /// </summary>
        /// <param name="shapeName">argument: shape name</param>
        /// <param name="color">argument: color</param>
        /// <param name="radius">argument: radius</param>
        public Circle(string shapeName, string color, double radius)
        {
            this.Color = color;
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets thhis sets the properties of radius.
        /// </summary>
        /// <value>This sets the properties of radius.
        /// </value>
        public double Radius { get; set; }

        /// <summary>
        /// This calculates circles area
        /// </summary>
        /// <returns>returns area as double</returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
