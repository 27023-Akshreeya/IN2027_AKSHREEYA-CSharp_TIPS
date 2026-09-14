namespace UsingLists.Domain;

/// <summary>
/// Represents the result of an operation.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets or sets a value indicating whether gets or sets whether the operation succeeded.
    /// </summary>
    /// <value>Whether the operation succeeded.
    /// </value>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets the operation message.
    /// </summary>
    /// <value>The operation message.
    /// </value>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <param name="message">Success message.</param>
    /// <returns>A successful result.</returns>
    public static Result Success(string message) => new Result { IsSuccess = true, Message = message };

    /// <summary>
    /// Creates a failed result.
    /// </summary>
    /// <param name="message">Failure message.</param>
    /// <returns>A failed result.</returns>
    public static Result Failure(string message) => new Result { IsSuccess = false, Message = message };
}