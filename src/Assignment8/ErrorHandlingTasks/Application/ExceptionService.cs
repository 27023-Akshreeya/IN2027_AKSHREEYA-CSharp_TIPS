using System;

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
    }
}
