namespace PatternMatching;

/// <summary>
/// Represents the base type for all shapes.
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Shape"/> class.
    /// </summary>
    /// <param name="name">Shape name.</param>
    public Shape(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// Gets or sets the shape name.
    /// </summary>
    /// <value> The shape name.</placeholder>
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Calculates the shape area.
    /// </summary>
    /// <returns>Calculated area.</returns>
    public abstract double CalculateArea();
}