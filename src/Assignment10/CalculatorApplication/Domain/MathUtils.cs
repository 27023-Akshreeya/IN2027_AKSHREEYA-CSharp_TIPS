using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication.Domain
{
    /// <summary>
    /// Provides basic arithmetic utility methods.
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Calculates the sum of two integers.
        /// </summary>
        /// <param name="number1">The first integer.</param>
        /// <param name="number2">The second integer.</param>
        /// <returns>The sum result.</returns>
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Calculates the difference between two integers.
        /// </summary>
        /// <param name="number1">The first integer.</param>
        /// <param name="number2">The second integer to subtract.</param>
        /// <returns>The difference result.</returns>
        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Calculates the product of two integers.
        /// </summary>
        /// <param name="number1">The first integer.</param>
        /// <param name="number2">The second integer.</param>
        /// <returns>The product result.</returns>
        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Calculates the quotient of two integers.
        /// </summary>
        /// <param name="number1">The dividend.</param>
        /// <param name="number2">The divisor.</param>
        /// <returns>The division result as a double.</returns>
        /// <exception cref="DivideByZeroException">Thrown when divisor is zero.</exception>
        public double Divide(int number1, int number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException("Error: Division by zero is not allowed.");
            }

            return (double)number1 / number2;
        }
    }
}
