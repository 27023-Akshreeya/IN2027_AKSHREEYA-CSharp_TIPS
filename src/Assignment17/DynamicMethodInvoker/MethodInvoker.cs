using System.Reflection;

namespace DynamicMethodInvoker;

/// <summary>
/// Provides functionality to invoke methods on objects dynamically by name.
/// </summary>
/// <remarks>Enables runtime method invocation using reflection.</remarks>
public class MethodInvoker
{
    /// <summary>
    /// Invokes a method by name on the specified object using reflection.
    /// </summary>
    /// <param name="obj">The object instance on which to invoke the method.</param>
    /// <param name="name">The name of the method to invoke.</param>
    public void InvokeMethod(object obj, string name)
    {
        if (obj is null)
        {
            return;
        }

        Type type = obj.GetType();
        MethodInfo? methodInfo = type.GetMethod(name);
        if (methodInfo is null)
        {
            Console.WriteLine("method not found");
            return;
        }

        Console.WriteLine("Calling the method dynamically");
        methodInfo?.Invoke(obj, null);
    }
}
