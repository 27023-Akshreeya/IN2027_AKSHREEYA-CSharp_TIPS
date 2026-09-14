using UsingDictionary.Domain;

namespace UsingDictionary.Application;

/// <summary>
/// Defines student management operations.
/// </summary>
public interface IStudentService
{
    /// <summary>
    /// Adds a new student.
    /// </summary>
    /// <param name="student">Student to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    bool AddNewStudent(Student student);

    /// <summary>
    /// Retrieves all students and grades.
    /// </summary>
    /// <returns>A collection of students and grades.</returns>
    IEnumerable<KeyValuePair<string, int>> GetAllStudents();

    /// <summary>
    /// Gets a student's grade.
    /// </summary>
    /// <param name="studentName">Student name.</param>
    /// <returns>The student's grade.</returns>
    int GetStudentGrade(string studentName);

    /// <summary>
    /// Removes a student.
    /// </summary>
    /// <param name="studentName">Student name.</param>
    /// <returns>True if removed; otherwise, false.</returns>
    bool RemoveStudent(string studentName);

    /// <summary>
    /// Checks whether a student exists.
    /// </summary>
    /// <param name="studentName">Student name.</param>
    /// <returns>True if the student exists; otherwise, false.</returns>
    bool StudentExists(string studentName);
}