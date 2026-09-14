namespace UsingDictionary.Presentation;

public delegate bool InputValidation(string input);

public static class Helper
{
    public static bool IsChoiceValid(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        return int.TryParse(input, out int choice) && choice >= 1 && choice <= 5;
    }

    public static bool IsNameValid(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        return name.All(char.IsLetter);
    }

    public static bool IsGradeValid(string grade)
    {
        if (string.IsNullOrWhiteSpace(grade))
        {
            return false;
        }

        return int.TryParse(grade, out int result) && result >= 0 && result <= 100;
    }

    public static bool IsExitChoiceValid(string input)
    {
        return input.Equals("y", System.StringComparison.OrdinalIgnoreCase)
               || input.Equals("n", System.StringComparison.OrdinalIgnoreCase);
    }
}
