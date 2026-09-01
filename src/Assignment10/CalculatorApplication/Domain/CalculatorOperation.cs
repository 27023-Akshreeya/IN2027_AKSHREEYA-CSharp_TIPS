using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Domain
{
    /// <summary>
    /// Specifies the type of mathematical operation to perform.
    /// </summary>
    public enum CalculatorOperation
    {
        /// <summary>
        /// Represents addition.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Represents subtraction.
        /// </summary>
        Subtract,

        /// <summary>
        /// Represents multiplication.
        /// </summary>
        Multiply,

        /// <summary>
        /// Represents division.
        /// </summary>
        Divide,

        /// <summary>
        /// Represents an unsupported or uninitialized state.
        /// </summary>
        Invalid,
    }
}
