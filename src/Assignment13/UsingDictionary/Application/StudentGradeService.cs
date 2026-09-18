using System.Collections.Generic;
using System.Linq;
using UsingDictionary.Domain;
using UsingDictionary.Infrastructure;

namespace UsingDictionary.Application;

/// <summary>
/// Provides student grade management services.
/// </summary>
public class StudentGradeService : IStudentService
{
    private readonly StudentGradeRepository<string, int> _studentGradeRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentGradeService"/> class.
    /// </summary>
    /// <param name="studentGradeRepository">Student grade repository.</param>
    public StudentGradeService(StudentGradeRepository<string, int> studentGradeRepository)
    {
        this._studentGradeRepository = studentGradeRepository;
    }

    /// <summary>
    /// Adds a new student.
    /// </summary>
    /// <param name="student">Student to add.</param>
    /// <returns>True if added; otherwise, false.</returns>
    public bool AddNewStudent(Student student)
    {
        if (this.DoesStudentExists(student.Name))
        {
            return false;
        }

        this._studentGradeRepository.AddStudent(student.Name, student.Grade);

        return true;
    }

    /// <summary>
    /// Removes a student.
    /// </summary>
    /// <param name="studentName">Student name.</param>
    /// <returns>True if removed; otherwise, false.</returns>
    public bool RemoveStudent(string studentName)
    {
        if (!this.DoesStudentExists(studentName))
        {
            return false;
        }

        this._studentGradeRepository.RemoveStudent(studentName);
        return true;
    }

    /// <summary>
    /// Checks whether a student exists.
    /// </summary>
    /// <param name="studentName">Student name.</param>
    /// <returns>True if the student exists; otherwise, false.</returns>
    public bool DoesStudentExists(string studentName)
    {
        return this.GetAllStudents().ContainsKey(studentName);
    }

    /// <summary>
    /// Gets a student's grade.
    /// </summary>
    /// <param name="studentName">Student name.</param>
    /// <returns>The student's grade.</returns>
    public int GetStudentGrade(string studentName)
    {
        if (!this.DoesStudentExists(studentName))
        {
            return -1;
        }

        return this.GetAllStudents()[studentName];
    }

    /// <summary>
    /// Retrieves all students and grades.
    /// </summary>
    /// <returns>A collection of students and grades.</returns>
    public Dictionary<string, int> GetAllStudents()
    {
        return this._studentGradeRepository.GetAllStudents()
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}