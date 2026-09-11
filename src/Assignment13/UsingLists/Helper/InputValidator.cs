namespace UsingLists.Helper
{
    public delegate bool InputValidation(string input);

    public static class InputValidator
    {
        public static bool IsChoiceValid(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                return false;
            }

            return int.TryParse(input, out int choice) && choice > 0 && choice <= 5;
        }

        public static bool IsBookValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static bool IsExitChoiceValid(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                return false;
            }

            return input.Equals("n", StringComparison.OrdinalIgnoreCase) ||
                     input.Equals("y", StringComparison.OrdinalIgnoreCase);
        }
    }
}
