namespace UsingStacks.Application;

public interface IStackService<T>
{
    int Count { get; }

    T Pop();

    void Push(T item);
}