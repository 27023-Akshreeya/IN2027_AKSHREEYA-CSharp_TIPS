using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousExceptionHandling
{
    /// <summary>
    /// Represents errors that occur during operations.
    /// </summary>
    internal class SimulateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulateException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public SimulateException(string message)
            : base(message)
        {
        }
    }
}
