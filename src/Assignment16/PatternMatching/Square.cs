namespace PatternMatching;

/// <summary>
/// Represents a square shape.
/// </summary>
public class Square
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Square"/> class.
    /// Initializes a square with the given side length.
    /// </summary>
    /// <param name="side">Square side length.</param>
    public Square(double side)
    {
        this.Side = side;
    }

    /// <summary>
    /// Gets or sets the side length.
    /// </summary>
    /// <value> The side length.</placeholder>
    /// </value>
    public double Side { get; set; }

    /// <summary>
    /// Calculates the square area.
    /// </summary>
    /// <returns>Square area.</returns>
    public double CalculateArea()
    {
        return this.Side * this.Side;
    }
}