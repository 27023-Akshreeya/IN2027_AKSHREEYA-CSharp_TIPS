using System;
using CalculatorApplication.Domain;

namespace CalculatorApplication.Application
{
    /// <summary>
    /// Orchestrates calculator operations by coordinating domain logic.
    /// </summary>
    public class CalculatorService
    {
        private readonly MathUtils _mathUtils;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorService"/> class.
        /// </summary>
        public CalculatorService()
        {
            this._mathUtils = new MathUtils();
        }

        /// <summary>
        /// Executes the requested math operation and packages the response into a DTO.
        /// </summary>
        /// <param name="operation">The operation type to run.</param>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>A data transfer object containing the result or error message.</returns>
        public CalculatorDTO Calculator(CalculatorOperation operation, int a, int b)
        {
            var output = new CalculatorDTO();

            try
            {
                output.Result = operation switch
                {
                    CalculatorOperation.Add => this._mathUtils.Add(a, b),
                    CalculatorOperation.Subtract => this._mathUtils.Subtract(a, b),
                    CalculatorOperation.Multiply => this._mathUtils.Multiply(a, b),
                    CalculatorOperation.Divide => this._mathUtils.Divide(a, b),
                    _ => throw new InvalidOperationException("Invalid Operation!")
                };

                output.IsSuccess = true;
                output.Message = "Calculation executed successfully.";
            }
            catch (DivideByZeroException ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                output.IsSuccess = false;
                output.Message = ex.Message;
            }
            catch (Exception ex)
            {
                output.IsSuccess = false;
                output.Message = $"An unexpected system error occurred: {ex.Message}";
            }

            return output;
        }
    }
}
