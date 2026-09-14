using UsingDictionary.Application;
using UsingDictionary.Domain;

namespace UsingDictionary.Presentation;

/// <summary>
/// Handles user interactions for student grade management.
/// </summary>
public class ConsoleUI
{
    private readonly IStudentService _studentService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
    /// </summary>
    /// <param name="studentGradeService">Student service.</param>
    public ConsoleUI(IStudentService studentGradeService)
    {
        this._studentService = studentGradeService;
    }

    /// <summary>
    /// Displays the main menu.
    /// </summary>
    public void Menu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Student Grade Manager\n1. Add students\n2. Remove a student\n3. Search for a student\n4. View all students and grades\n5. Exit");
            string choice = this.GetInputWithAttempts("Enter your choice: ", Helper.IsChoiceValid, "Invalid choice!");

            switch (choice)
            {
                case "1":
                    this.AddNewStudents();
                    break;

                case "2":
                    this.RemoveStudent();
                    break;

                case "3":
                    this.SearchStudent();
                    break;

                case "4":
                    this.ViewAllStudents();
                    break;

                case "5":
                    exit = true;
                    break;
            }
        }
    }

    /// <summary>
    /// Adds new students and their grades.
    /// </summary>
    private void AddNewStudents()
    {
        Console.WriteLine();
        Console.WriteLine("Enter details of 5 students");

        for (int studentCount = 0; studentCount < 5; studentCount++)
        {
            string studentName = this.GetInputWithAttempts($"Enter name of student no {studentCount + 1}: ", Helper.IsNameValid, "Invalid name!");

            if (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Couldn't add student.");
                continue;
            }

            string gradeInput = this.GetInputWithAttempts("Enter student grade (0-100): ", Helper.IsGradeValid, "Invalid grade!");

            if (string.IsNullOrWhiteSpace(gradeInput))
            {
                Console.WriteLine("Couldn't add student.");
                continue;
            }

            int grade = int.Parse(gradeInput);

            Student student = new Student(studentName, grade);

            if (!this._studentService.AddNewStudent(student))
            {
                Console.WriteLine(
                    $"Student '{studentName}' already exists.");
                continue;
            }

            Console.WriteLine("Student added successfully.");
        }
    }

    /// <summary>
    /// Removes a student.
    /// </summary>
    private void RemoveStudent()
    {
        Console.WriteLine();

        string studentName = this.GetInputWithAttempts("Enter student name to remove: ", Helper.IsNameValid, "Invalid name!");

        if (string.IsNullOrWhiteSpace(studentName))
        {
            return;
        }

        bool removed = this._studentService.RemoveStudent(studentName);

        if (removed)
        {
            Console.WriteLine("Student removed successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    /// <summary>
    /// Searches for a student.
    /// </summary>
    private void SearchStudent()
    {
        Console.WriteLine();

        string studentName = this.GetInputWithAttempts("Enter student name to search: ", Helper.IsNameValid, "Invalid name!");

        if (string.IsNullOrWhiteSpace(studentName))
        {
            return;
        }

        if (!this._studentService.StudentExists(studentName))
        {
            Console.WriteLine("Student not found.");
            return;
        }

        int grade = this._studentService.GetStudentGrade(studentName);

        Console.WriteLine(
            $"Student: {studentName} | Grade: {grade}");
    }

    /// <summary>
    /// Displays all students and grades.
    /// </summary>
    private void ViewAllStudents()
    {
        Console.WriteLine("\nStudents and Grades\n");

        var students = this._studentService.GetAllStudents();

        foreach (var student in students)
        {
            Console.WriteLine($"Student: {student.Key} | Grade: {student.Value}");
        }
    }

    /// <summary>
    /// Gets validated input from the user.
    /// </summary>
    /// <param name="input">Input prompt.</param>
    /// <param name="validator">Input validator.</param>
    /// <param name="invalidInput">Invalid input message.</param>
    /// <returns>The validated input.</returns>
    private string GetInputWithAttempts(string input, InputValidation validator, string invalidInput)
    {
        for (int tries = 3; tries > 0; tries--)
        {
            Console.Write($"\nAttempts remaining: {tries}\n{input}");

            string userInput = Console.ReadLine() ?? string.Empty;

            if (validator(userInput))
            {
                return userInput;
            }

            Console.WriteLine(invalidInput);
        }

        return string.Empty;
    }
}