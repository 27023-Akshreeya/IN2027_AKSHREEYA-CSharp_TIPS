namespace ErrorHandlingTasks.Presentation
{
    public static class InputValidator
    {
        public static bool IsNumberValid(string input)
        {
            return int.TryParse(input, out var _);
        }
    }
}
