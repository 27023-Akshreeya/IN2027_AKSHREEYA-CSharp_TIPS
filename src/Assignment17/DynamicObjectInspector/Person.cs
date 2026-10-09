/// <summary>
/// Represents a person with basic details that can be inspected and modified at runtime.
/// </summary>
internal class Person
{
    /// <summary>
    /// Gets or sets the person's name.
    /// </summary>
    /// <value>The person's name.</placeholder>
    /// </value>
    public string Name { get; set; } = "Alice";

    /// <summary>
    /// Gets or sets the person's age.
    /// </summary>
    /// <value>The person's age.</placeholder>
    /// </value>
    public int Age { get; set; } = 30;

    /// <summary>
    /// Gets or sets the city where the person resides.
    /// </summary>
    /// <value>The city where the person resides.</placeholder>
    /// </value>
    public string City { get; set; } = "New york";
}