namespace UsingQueues.Presentation;

/// <summary>
/// Represents an input validation method.
/// </summary>
/// <param name="input">Input to validate.</param>
/// <returns>True if valid; otherwise, false.</returns>
public delegate bool InputValidator(string input);

/// <summary>
/// Provides input validation methods.
/// </summary>
public static class InputValidation
{
    /// <summary>
    /// Validates a person's name.
    /// </summary>
    /// <param name="name">Name to validate.</param>
    /// <returns>True if valid; otherwise, false.</returns>
    public static bool IsNameValid(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        return name.All(char.IsLetter);
    }
}