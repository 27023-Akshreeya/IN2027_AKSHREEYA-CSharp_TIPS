namespace UsingStacks.Application;

/// <summary>
/// Provides stack operations.
/// </summary>
/// <typeparam name="T">Type of elements stored in the stack.</typeparam>
public class StackService<T> : IStackService<T>
{
    private readonly Stack<T> _stack = new ();

    /// <summary>
    /// Gets the number of items in the stack.
    /// </summary>
    /// <value>The number of items in the stack.
    /// </value>
    public int Count => this._stack.Count;

    /// <summary>
    /// Adds an item to the top of the stack.
    /// </summary>
    /// <param name="item">Item to add.</param>
    public void Push(T item)
    {
        this._stack.Push(item);
    }

    /// <summary>
    /// Removes and returns the item from the top of the stack.
    /// </summary>
    /// <returns>The top item.</returns>
    public T Pop()
    {
        return this._stack.Pop();
    }
}
