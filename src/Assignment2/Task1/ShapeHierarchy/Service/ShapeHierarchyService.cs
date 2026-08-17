using System;
using ShapeHierarchy.Model;

namespace ShapeHierarchy.Service
{
    /// <summary>
    /// This is service class where all control operations take place
    /// </summary>
    public class ShapeHierarchyService
    {
        /// <summary>
        /// Calculates the area of the specified shape.
        /// </summary>
        /// <param name="shape">The shape for which to calculate the area.</param>
        /// <returns>The area of the specified shape.</returns>
        /// <exception cref="ArgumentNullException">Thrown when shape is null.</exception>
        public double CalculateArea(Shape shape)
        {
            if (shape.Equals(null))
            {
                throw new ArgumentNullException(nameof(shape));
            }

            return shape.CalculateArea();
        }
    }
}