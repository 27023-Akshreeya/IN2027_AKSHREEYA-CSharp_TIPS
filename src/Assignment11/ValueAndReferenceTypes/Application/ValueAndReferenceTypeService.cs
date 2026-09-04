using System;
using ValueAndReferenceTypes.Domain;

namespace ValueAndReferenceTypes.Application
{
    /// <summary>
    /// Service demonstrating behavior differences between value types and reference types.
    /// </summary>
    public class ValueAndReferenceTypeService
    {
        /// <summary>
        /// Creates and returns a new student instance.
        /// </summary>
        /// <param name="studentName">The name of the student.</param>
        /// <returns>A new Student object.</returns>
        public Student AddStudent(string studentName)
        {
            return new Student { Name = studentName };
        }

        /// <summary>
        /// Creates and returns a new teacher instance.
        /// </summary>
        /// <param name="teacherName">The name of the teacher.</param>
        /// <returns>A new Teacher object.</returns>
        public Teacher AddTeacher(string teacherName)
        {
            return new Teacher { Name = teacherName };
        }

        /// <summary>
        /// Updates the name of the provided student reference.
        /// </summary>
        /// <param name="newStudent">The student instance to modify.</param>
        /// <param name="newStudentName">The new name to apply.</param>
        public void ModifyStudentName(Student newStudent, string newStudentName)
        {
            newStudent.Name = newStudentName;
        }

        /// <summary>
        /// Updates the name of the provided teacher reference.
        /// </summary>
        /// <param name="newTeacher">The teacher instance to modify.</param>
        /// <param name="newTeacherName">The new name to apply.</param>
        public void ModifyTeacherName(Teacher newTeacher, string newTeacherName)
        {
            newTeacher.Name = newTeacherName;
        }

        /// <summary>
        /// Allocates a large integer array directly on the managed heap.
        /// </summary>
        /// <returns>The allocated integer array.</returns>
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

        /// <summary>
        /// Performs localized mathematical operations using local variables on the stack.
        /// </summary>
        /// <returns>The calculated summation integer.</returns>
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
