using System;
using ErrorHandlingTasks.Domain;

namespace ErrorHandlingTasks.Application
{
    public class ExceptionService
    {
        public int PerformDivision(int numerator, int denominator)
        {
            try
            {
                return numerator / denominator;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
        }

        internal int AccessArrayElement(int index, int[] array)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidIndexAccessException(ex.Message);
            }
        }
    }
}
