using UsingDictionary.Domain;
using UsingDictionary.Infrastructure;

namespace UsingDictionary.Application;

public class StudentGradeService : IStudentService
{
    private readonly StudentGradeRepository<string, int> _studentGradeRepository;

    public StudentGradeService(StudentGradeRepository<string, int> studentGradeRepository)
    {
        this._studentGradeRepository = studentGradeRepository;
    }

    public bool AddNewStudent(Student student)
    {
        if (this._studentGradeRepository.ContainsKey(student.Name))
        {
            return false;
        }

        this._studentGradeRepository.Add(student.Name, student.Grade);

        return true;
    }

    public bool RemoveStudent(string studentName)
    {
        return this._studentGradeRepository.Remove(studentName);
    }

    public bool StudentExists(string studentName)
    {
        return this._studentGradeRepository.ContainsKey(studentName);
    }

    public int GetStudentGrade(string studentName)
    {
        return this._studentGradeRepository.Get(studentName);
    }

    public IEnumerable<KeyValuePair<string, int>> GetAllStudents()
    {
        return this._studentGradeRepository.GetAllStudents();
    }
}