namespace LoggingSystem
{
    /// <summary>
    /// Provides thread-safe error logging functionality for multiple users.
    /// </summary>
    public static class Logger
    {
        private static readonly object LockObject = new object();

        /// <summary>
        /// Writes an error message to the specified user's log file.
        /// </summary>
        /// <param name="userName">Name of the user generating the error.</param>
        /// <param name="errorMessage">Error message to be logged.</param>
        public static void LogError(string userName, string errorMessage)
        {
            string fileName = userName + "_errors.txt";

            lock (LockObject)
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine(DateTime.Now + " - " + errorMessage);
                }
            }
        }
    }
}