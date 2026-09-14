namespace UsingDictionary.Domain;

/// <summary>
/// Represents a student.
/// </summary>
public class Student
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Student"/> class.
    /// </summary>
    /// <param name="name">Student name.</param>
    /// <param name="grade">Student grade.</param>
    public Student(string name, int grade)
    {
        this.Name = name;
        this.Grade = grade;
    }

    /// <summary>
    /// Gets or sets the student name.
    /// </summary>
    /// <value>The student name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the student grade.
    /// </summary>
    /// <value>The student grade.
    /// </value>
    public int Grade { get; set; }
}
