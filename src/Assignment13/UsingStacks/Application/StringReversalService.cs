using System.Text;

namespace UsingStacks.Application;

/// <summary>
/// Provides string reversal operations.
/// </summary>
public class StringReversalService : IReversalService<char>
{
    private IStackService<char> _stackService;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringReversalService"/> class.
    /// </summary>
    /// <param name="stackService">Stack service.</param>
    public StringReversalService(IStackService<char> stackService)
    {
        this._stackService = stackService;
    }

    /// <summary>
    /// Reverses the specified string.
    /// </summary>
    /// <param name="orignalString">String to reverse.</param>
    /// <returns>The reversed string.</returns>
    public string Reverse(string orignalString)
    {
        var charaterStack = this.PushToStack(orignalString);
        return this.PopFromStack(charaterStack);
    }

    /// <summary>
    /// Builds a string by popping characters from the stack.
    /// </summary>
    /// <param name="charaterStack">Stack of characters.</param>
    /// <returns>The reversed string.</returns>
    public string PopFromStack(StackService<char> charaterStack)
    {
        var sb = new StringBuilder(string.Empty);
        while (charaterStack.Count > 0)
        {
            char character = charaterStack.Pop();
            sb.Append(character);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Pushes all characters of a string onto a stack.
    /// </summary>
    /// <param name="orignalString">String to process.</param>
    /// <returns>A stack containing the string characters.</returns>
    public StackService<char> PushToStack(string orignalString)
    {
        var stack = new StackService<char>();
        foreach (char charater in orignalString)
        {
            stack.Push(charater);
        }

        return stack;
    }
}
