using System.Collections.Generic;

namespace UsingDictionary.Infrastructure;

/// <summary>
/// Repository for managing student grades.
/// </summary>
/// <typeparam name="TKey">Type of the student identifier.</typeparam>
/// <typeparam name="TValue">Type of the grade value.</typeparam>
public class StudentGradeRepository<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _studentsGrade;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentGradeRepository{TKey, TValue}"/> class.
    /// </summary>
    public StudentGradeRepository()
    {
        this._studentsGrade = new Dictionary<TKey, TValue>();
    }

    /// <summary>
    /// Adds a student and grade.
    /// </summary>
    /// <param name="studentName">Student identifier.</param>
    /// <param name="studentGrade">Student grade.</param>
    public void AddStudent(TKey studentName, TValue studentGrade)
    {
        this._studentsGrade.Add(studentName, studentGrade);
    }

    /// <summary>
    /// Removes a student.
    /// </summary>
    /// <param name="studentName">Student identifier.</param>
    public void RemoveStudent(TKey studentName)
    {
        this._studentsGrade.Remove(studentName);
    }

    /// <summary>
    /// Retrieves all students and grades.
    /// </summary>
    /// <returns>A collection of student-grade pairs.</returns>
    public IEnumerable<KeyValuePair<TKey, TValue>> GetAllStudents()
    {
        return this._studentsGrade;
    }
}
