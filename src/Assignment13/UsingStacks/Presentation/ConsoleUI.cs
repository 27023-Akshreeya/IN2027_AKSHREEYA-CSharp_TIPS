using UsingStacks.Application;

namespace UsingStacks.Presentation;

/// <summary>
/// Handles user interactions for string reversal.
/// </summary>
public class ConsoleUI
{
    private IReversalService<char> _reversalService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConsoleUI"/> class.
    /// </summary>
    /// <param name="reversalService">String reversal service.</param>
    public ConsoleUI(IReversalService<char> reversalService)
    {
        this._reversalService = reversalService;
    }

    /// <summary>
    /// Runs the string reversal workflow.
    /// </summary>
    public void Run()
    {
        Console.Write(StringReversalResource.Darshboard);
        string orignalString = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(orignalString))
        {
            Console.WriteLine(StringReversalResource.Invalid);
            return;
        }

        string reversedString = this._reversalService.Reverse(orignalString);
        Console.WriteLine(StringReversalResource.OriginalString + orignalString + StringReversalResource.reversedString + "\n" + reversedString);
    }
}
