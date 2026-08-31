using System;

namespace ErrorHandlingTasks.Domain
{
    /// <summary>
    /// Represents an exception that is thrown when a user provides invalid or unacceptable input to the application.
    /// </summary>
    public class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="InvalidUserInputException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}