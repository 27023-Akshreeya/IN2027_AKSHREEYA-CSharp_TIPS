using System.Reflection;

namespace DynamicObjectInspector;

/// <summary>
/// Inspects and manipulates the properties of an object at runtime.
/// </summary>
/// <remarks>Provides methods to display property values and update property values of the specified
/// object.</remarks>
public class ObjectInspector
{
    /// <summary>
    /// Displays the names and current values of all public properties of the specified person.
    /// </summary>
    /// <param name="person">The person whose property values will be displayed.</param>
    public void DisplayValue(object person)
    {
        Type type = person.GetType();
        Console.WriteLine($"Object Type: {type.Name}\nProperties:");
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(person)}");
        }
    }

    /// <summary>
    /// Updates the value of a specified property on the given object.
    /// </summary>
    /// <param name="person">The object whose property value will be updated.</param>
    /// <param name="newName">The name of the property to update.</param>
    /// <param name="newValue">The new value to assign to the property.</param>
    public void UpdateValue(object person, string newName, object newValue)
    {
        Type type = person.GetType();
        PropertyInfo? property = type.GetProperty(newName);
        if (property == null)
        {
            Console.WriteLine($"Property '{newName}' not found.");
            return;
        }

        property.SetValue(person, Convert.ChangeType(newValue, property.PropertyType));
        Console.WriteLine($"{newName} updated successfully.");
    }
}