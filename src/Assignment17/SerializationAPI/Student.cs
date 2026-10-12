using System;

/// <summary>
/// Represents a student record for serialization testing.
/// </summary>
public class Student
{
    /// <summary>
    /// Gets or sets student ID
    /// </summary>
    /// <value> Integer value
    /// </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets student Name
    /// </summary>
    /// <value>string value
    /// </value>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets student Marks
    /// </summary>
    /// <value> Student Marks</placeholder>
    /// </value>
    public double Marks { get; set; }
}