using System;
using ErrorHandlingTasks.Domain;

namespace ErrorHandlingTasks.Application
{
    /// <summary>
    /// Provides methods that demonstrate exception handling scenarios,
    /// including division operations and array element access.
    /// </summary>
    public class ExceptionService
    {
        /// <summary>
        /// Performs division between two integer values.
        /// </summary>
        /// <param name="numerator">The dividend value.</param>
        /// <param name="denominator">The divisor value.</param>
        /// <returns>The result of dividing the numerator by the denominator.</returns>
        /// <exception cref="DivideByZeroException"> Thrown when the denominator is zero.
        /// </exception>
        public int PerformDivision(int numerator, int denominator)
        {
            return numerator / denominator;
        }

        /// <summary>
        /// Retrieves an element from the specified array using the provided index.
        /// </summary>
        /// <param name="index">The position of the element to access.</param>
        /// <param name="array">The array from which the element is retrieved.</param>
        /// <returns>The value stored at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException"> Thrown when the specified index is outside the bounds of the array.
        /// </exception>
        internal int AccessArrayElement(int index, int[] array)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidIndexAccessException($"Error : {index} is out of range!");
            }
        }
    }
}