using System;

namespace ErrorHandlingTasks.Domain
{
    /// <summary>
    /// Represents an exception that is thrown when an attempt is made to access an array element using an invalid index.
    /// </summary>
    public class InvalidIndexAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="InvalidIndexAccessException"/> class with a specifiederror message.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public InvalidIndexAccessException(string message)
            : base(message)
        {
        }
    }
}