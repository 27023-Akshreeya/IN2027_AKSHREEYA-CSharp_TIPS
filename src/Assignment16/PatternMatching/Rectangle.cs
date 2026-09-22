namespace PatternMatching;

/// <summary>
/// Represents a rectangle shape.
/// </summary>
public class Rectangle : Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rectangle"/> class.
    /// Initializes a rectangle with length and width.
    /// </summary>
    /// <param name="length">Rectangle length.</param>
    /// <param name="width">Rectangle width.</param>
    public Rectangle(double length, double width)
        : base("Rectangle")
    {
        this.Length = length;
        this.Width = width;
    }

    /// <summary>
    /// Gets or sets the rectangle length.
    /// </summary>
    /// <value> The rectangle length.</placeholder>
    /// </value>
    public double Length { get; set; }

    /// <summary>
    /// Gets or sets the rectangle width.
    /// </summary>
    /// <value> The rectangle width.</placeholder>
    /// </value>
    public double Width { get; set; }

    /// <summary>
    /// Calculates the rectangle area.
    /// </summary>
    /// <returns>Rectangle area.</returns>
    public override double CalculateArea()
    {
        return this.Length * this.Width;
    }
}