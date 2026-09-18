using System.Linq;

namespace UsingDictionary.Presentation;

/// <summary>
/// Represents input validation methods.
/// </summary>
/// <param name="input">Input to validate.</param>
/// <returns>True if valid; otherwise, false.</returns>
public delegate bool InputValidation(string input);

/// <summary>
/// Provides input validation helpers.
/// </summary>
public static class Helper
{
    /// <summary>
    /// Validates menu choice input.
    /// </summary>
    /// <param name="input">Choice value.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    public static bool IsChoiceValid(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        return int.TryParse(input, out int choice) && choice >= 1 && choice <= 5;
    }

    /// <summary>
    /// Validates a student name.
    /// </summary>
    /// <param name="name">Student name.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    public static bool IsNameValid(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        return name.All(char.IsLetter);
    }

    /// <summary>
    /// Validates a grade value.
    /// </summary>
    /// <param name="grade">Grade input.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    public static bool IsGradeValid(string grade)
    {
        if (string.IsNullOrWhiteSpace(grade))
        {
            return false;
        }

        return int.TryParse(grade, out int result) && result >= 0 && result <= 100;
    }

    /// <summary>
    /// Validates exit confirmation input.
    /// </summary>
    /// <param name="input">Exit choice.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    public static bool IsExitChoiceValid(string input)
    {
        return input.Equals("y", System.StringComparison.OrdinalIgnoreCase)
               || input.Equals("n", System.StringComparison.OrdinalIgnoreCase);
    }
}
