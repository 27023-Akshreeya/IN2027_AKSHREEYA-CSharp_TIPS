using System;
using CalculatorApplication.Domain;

namespace CalculatorApplication.Application;

/// <summary>
/// Orchestrates calculator operations by coordinating domain logic.
/// </summary>
public class CalculatorService
{
    private readonly MathUtilities _mathUtilities;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorService"/> class.
    /// </summary>
    public CalculatorService()
    {
        this._mathUtilities = new MathUtilities();
    }

    /// <summary>
    /// Executes the requested math operation and packages the response into a DTO.
    /// </summary>
    /// <param name="operation">The operation type to run.</param>
    /// <param name="a">The first operand.</param>
    /// <param name="b">The second operand.</param>
    /// <returns>A data transfer object containing the result or error message.</returns>
    public CalculatorDTO Calculator(Calculator operation, int a, int b)
    {
        var output = new CalculatorDTO();

        try
        {
            output.Result = operation switch
            {
                Domain.Calculator.Add => this._mathUtilities.Add(a, b),
                Domain.Calculator.Subtract => this._mathUtilities.Subtract(a, b),
                Domain.Calculator.Multiply => this._mathUtilities.Multiply(a, b),
                Domain.Calculator.Divide => this._mathUtilities.Divide(a, b),
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
