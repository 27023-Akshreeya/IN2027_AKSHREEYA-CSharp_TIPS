namespace ValueAndReferenceTypes.Application
{
    public struct Teacher
    {
        public string Name { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
    }

    public class ValueAndReferenceTypeService
    {
        public Student AddStudent(string studentName)
        {
            return new Student { Name = studentName };
        }

        public Teacher AddTeacher(string teacherName)
        {
            return new Teacher { Name = teacherName };
        }

        public void ModifyStudentName(Student newStudent, string newStudentName)
        {
           newStudent.Name = newStudentName;
        }

        public void ModifyTeacherName(Teacher newTeacher, string newTeacherName)
        {
            newTeacher.Name = newTeacherName;
        }
    }
}
