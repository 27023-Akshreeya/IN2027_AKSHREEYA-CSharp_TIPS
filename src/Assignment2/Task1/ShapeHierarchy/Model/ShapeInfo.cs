using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops_basic.Model
{
    /// <summary>
    /// This abstract class serves as a base for different shape types, providing common properties and methods for calculating and printing the area of shapes. It defines an abstract method for area calculation that must be implemented by derived classes.
    /// </summary>
    public abstract class ShapeInfo
    {
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
        /// This i
        /// </summary>
        public void PrintArea()
        {
            double area = this.CalculateArea();
            Console.WriteLine($"\nThe color of the {this.ShapeName}: {this.Color}\nThe area of the {this.ShapeName}: {area}");
        }
    }
}