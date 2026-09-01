using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Domain
{
    /// <summary>
    /// Encapsulates the result, status, and message of a calculator operation.
    /// </summary>
    public class CalculatorDTO
    {
        /// <summary>
        /// Gets or sets the numerical output of the calculation.
        /// </summary>
        /// <value>The numerical output of the calculation.
        /// </value>
        public double Result { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the calculation succeeded.
        /// </summary>
        /// <value>A value indicating whether the calculation succeeded.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets feedback or error messages details.
        /// </summary>
        /// <value>Feedback or error messages details.
        /// </value>
        public string Message { get; set; } = string.Empty;
    }
}
