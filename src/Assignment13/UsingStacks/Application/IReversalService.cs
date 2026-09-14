namespace UsingStacks.Application;

public interface IReversalService<T>
{
    string PopFromStack(StackService<T> charaterStack);

    StackService<T> PushToStack(string orignalString);

    string Reverse(string orignalString);
}