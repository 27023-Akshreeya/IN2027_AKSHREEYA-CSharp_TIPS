namespace UsingStacks.Application;

/// <summary>
/// Defines stack operations.
/// </summary>
/// <typeparam name="T">Type of elements stored in the stack.</typeparam>
public interface IStackService<T>
{
    /// <summary>
    /// Gets the number of items in the stack.
    /// </summary>
    /// <value> The number of items in the stack.
    /// </value>
    int Count { get; }

    /// <summary>
    /// Removes and returns the top item from the stack.
    /// </summary>
    /// <returns>The top item.</returns>
    T Pop();

    /// <summary>
    /// Adds an item to the top of the stack.
    /// </summary>
    /// <param name="item">Item to add.</param>
    void Push(T item);
}