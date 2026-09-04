using System;
using ValueAndReferenceTypes.Application;

namespace ValueAndReferenceTypes.Presentation
{
    /// <summary>
    /// Handles user interaction and presentation logic for testing value and reference types.
    /// </summary>
    public class ConsoleUI
    {
        private readonly ValueAndReferenceTypeService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
        /// </summary>
        /// <param name="service">The underlying logic service module.</param>
        public ConsoleUI(ValueAndReferenceTypeService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Prompts user input to demonstrate reference mutating versus value copying behaviors.
        /// </summary>
        public void Task1()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Task 1: Value and Reference Types\n\nAdd new Student\nEnter student name:");
                string studentName = Console.ReadLine() ?? string.Empty;
                if (!Validator.IsValid(studentName))
                {
                    Console.WriteLine("Student name is invalid!");
                    continue;
                }

                Console.Write("Add new teacher\nEnter teacher name:");
                string teacherName = Console.ReadLine() ?? string.Empty;
                if (!Validator.IsValid(teacherName))
                {
                    Console.WriteLine("Teacher Name is invalid!");
                    continue;
                }

                var newStudent = this._service.AddStudent(studentName);
                Console.WriteLine("\nStudent name before modification: " + newStudent.Name);
                var newTeacher = this._service.AddTeacher(teacherName);
                Console.WriteLine("Teacher name before modification: " + newTeacher.Name);
                Console.Write("Enter modifiyed student name:");
                string newStudentName = Console.ReadLine() ?? string.Empty;
                if (!Validator.IsValid(newStudentName))
                {
                    Console.WriteLine("Student name is invalid!");
                    continue;
                }

                Console.Write("Enter modifiyed Teacher name:");
                string newTeacherName = Console.ReadLine() ?? string.Empty;
                if (!Validator.IsValid(newTeacherName))
                {
                    Console.WriteLine("Teacher Name is invalid!");
                    continue;
                }

                this._service.ModifyStudentName(newStudent, newStudentName);
                this._service.ModifyTeacherName(newTeacher, newTeacherName);
                Console.WriteLine($"\nStudent name after modification: {newStudent.Name}");
                Console.WriteLine($"Teacher name after modification: {newTeacher.Name}");
                isValid = true;
            }
        }

        /// <summary>
        /// Triggers execution paths for testing stack allocations and heavy heap allocations.
        /// </summary>
        public void Task2()
        {
            Console.WriteLine("\nTask 2\nAllocating a large integer array");
            var array = this._service.AllocateOnHeap();
            Console.WriteLine($"Array allocation is done\nFirst element: {array[0]} | last element: {array[^1]}");
            Console.WriteLine("Performing calculation with local value types on the stack");
            Console.WriteLine($"Calculation done. Result: {this._service.AllocateOnStack()}");
        }

        /// <summary>
        /// Orchestrates sequential flow execution across all defined test tasks.
        /// </summary>
        public void Execute()
        {
            this.Task1();
            this.Task2();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
