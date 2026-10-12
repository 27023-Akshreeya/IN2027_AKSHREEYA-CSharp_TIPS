using System.Reflection;

/// <summary>
/// Serializes objects using Reflection.
/// </summary>
public static class ReflectionSerializer
{
    /// <summary>
    /// Converts an object's public properties into a string.
    /// </summary>
    /// <param name="obj">Input object</param>
    /// <returns> returns string</returns>
    public static string Serialize(object obj)
    {
        Type type = obj.GetType();

        var result = new List<string>();

        foreach (PropertyInfo property in type.GetProperties())
        {
            object? value = property.GetValue(obj);
            result.Add($"{property.Name}={value}");
        }

        return string.Join(", ", result);
    }
}
