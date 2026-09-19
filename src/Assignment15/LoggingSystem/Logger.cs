namespace LoggingSystem
{
    /// <summary>
    /// 
    /// </summary>
    public static class Logger
    {
        private static readonly object LockObject = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="errorMessage"></param>
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
