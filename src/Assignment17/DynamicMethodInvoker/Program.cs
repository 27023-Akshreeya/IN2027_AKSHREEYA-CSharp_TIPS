namespace DynamicMethodInvoker;

/// <summary>
/// Defines the application's entry point and coordinates method invocation on the Greetings class.
/// </summary>
internal class Program
{
    /// <summary>
    /// Serves as the entry point for the application.
    /// </summary>
    /// <param name="args">An array of command-line arguments.</param>
    private static void Main(string[] args)
    {
        Greetings greetings = new Greetings();
        MethodInvoker methodInvoker = new MethodInvoker();
        methodInvoker.InvokeMethod(greetings, "MorningGreets");
        methodInvoker.InvokeMethod(greetings, "EveningGreets");
        methodInvoker.InvokeMethod(greetings, "NightGreetings");
    }
}
