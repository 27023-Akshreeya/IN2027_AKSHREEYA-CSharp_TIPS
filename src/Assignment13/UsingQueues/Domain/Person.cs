namespace UsingQueues.Domain;

/// <summary>
/// Represents a person in the queue.
/// </summary>
public class Person
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// </summary>
    /// <param name="name">Person name.</param>
    public Person(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// Gets or sets the person's name.
    /// </summary>
    /// <value>The person's name.
    /// </value>
    public string Name { get; set; }
}
