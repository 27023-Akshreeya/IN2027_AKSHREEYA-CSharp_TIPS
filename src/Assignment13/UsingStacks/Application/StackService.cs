namespace UsingStacks.Application;

public class StackService<T> : IStackService<T>
{
    private readonly Stack<T> _stack = new ();

    public int Count => this._stack.Count;

    public void Push(T item)
    {
        this._stack.Push(item);
    }

    public T Pop()
    {
        return this._stack.Pop();
    }
}
