using System;

namespace PatternMatching;

/// <summary>
/// Represents a circle shape.
/// </summary>
public class Circle : Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class.
    /// Initializes a circle with the given radius.
    /// </summary>
    /// <param name="radius">Circle radius.</param>
    public Circle(double radius)
        : base("Circle")
    {
        this.Radius = radius;
    }

    /// <summary>
    /// Gets or sets the circle radius.
    /// </summary>
    /// <value> The circle radius.</placeholder>
    /// </value>
    public double Radius { get; set; }

    /// <summary>
    /// Calculates the circle area.
    /// </summary>
    /// <returns>Circle area.</returns>
    public override double CalculateArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }
}