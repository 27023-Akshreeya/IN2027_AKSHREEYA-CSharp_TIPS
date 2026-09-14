namespace UsingQueues.Presentation;

public delegate bool InputValidator(string input);

public static class InputValidation
{
    public static bool IsNameValid(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        return name.All(char.IsLetter);
    }
}