using System;
using ValueAndReferenceTypes.Domain;

namespace ValueAndReferenceTypes.Application
{
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

        public int[] AllocateOnHeap()
        {
            Console.WriteLine("Allocating a large array on the Heap...");
            int[] largeArray = new int[10_000_000];
            for (int i = 0; i < largeArray.Length; i++)
            {
                largeArray[i] = i;
            }

            return largeArray;
        }

        public int AllocateOnStack()
        {
            int a1 = 1;
            int a2 = 2;
            int a3 = 3;
            int a4 = 4;
            int a5 = 5;
            int b1 = 6;
            int b2 = 7;
            int b3 = 8;
            int b4 = 9;
            int b5 = 10;
            int sum = 0;
            for (int i = 0; i < 50_000_000; i++)
            {
                sum += (a1 * b1) + (a2 * b2) + (a3 * b3) + (a4 * b4) + (a5 * b5) + i;
            }

            return sum;
        }
    }
}
