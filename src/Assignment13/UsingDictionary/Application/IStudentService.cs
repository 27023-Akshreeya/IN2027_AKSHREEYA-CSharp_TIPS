using UsingDictionary.Domain;

namespace UsingDictionary.Application;

public interface IStudentService
{
    bool AddNewStudent(Student student);

    IEnumerable<KeyValuePair<string, int>> GetAllStudents();

    int GetStudentGrade(string studentName);

    bool RemoveStudent(string studentName);

    bool StudentExists(string studentName);
}