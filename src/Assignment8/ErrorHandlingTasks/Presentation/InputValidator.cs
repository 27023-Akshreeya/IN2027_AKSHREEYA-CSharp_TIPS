namespace ErrorHandlingTasks.Presentation
{
    /// <summary>
    /// Validates user input.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Checks whether the input is a valid integer.
        /// </summary>
        /// <param name="input">Input value.</param>
        /// <returns>True if valid; otherwise, false.</returns>
        public static bool IsNumberValid(string input)
        {
            return int.TryParse(input, out var _);
        }
    }
}