namespace PatternMatching;

/// <summary>
/// Represents a triangle shape.
/// </summary>
public class Triangle : Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class.
    /// </summary>
    /// <param name="baseValue">Triangle base.</param>
    /// <param name="height">Triangle height.</param>
    public Triangle(double baseValue, double height)
        : base("Triangle")
    {
        this.Base = baseValue;
        this.Height = height;
    }

    /// <summary>
    /// Gets or sets the triangle base.
    /// </summary>
    /// <value> The triangle base.</placeholder>
    /// </value>
    public double Base { get; set; }

    /// <summary>
    /// Gets or sets the triangle height.
    /// </summary>
    /// <value> The triangle height.</placeholder>
    /// </value>
    public double Height { get; set; }

    /// <summary>
    /// Calculates the triangle area.
    /// </summary>
    /// <returns>Triangle area.</returns>
    public override double CalculateArea()
    {
        return 0.5 * this.Base * this.Height;
    }
}