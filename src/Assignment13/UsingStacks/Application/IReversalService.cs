namespace UsingStacks.Application;

/// <summary>
/// Defines string reversal operations.
/// </summary>
/// <typeparam name="T">Type of elements stored in the stack.</typeparam>
public interface IReversalService<T>
{
    /// <summary>
    /// Builds a string by popping elements from a stack.
    /// </summary>
    /// <param name="charaterStack">Stack containing characters.</param>
    /// <returns>The resulting string.</returns>
    string PopFromStack(StackService<T> charaterStack);

    /// <summary>
    /// Pushes the characters of a string onto a stack.
    /// </summary>
    /// <param name="orignalString">String to process.</param>
    /// <returns>A stack containing the string characters.</returns>
    StackService<T> PushToStack(string orignalString);

    /// <summary>
    /// Reverses the specified string.
    /// </summary>
    /// <param name="orignalString">String to reverse.</param>
    /// <returns>The reversed string.</returns>
    string Reverse(string orignalString);
}