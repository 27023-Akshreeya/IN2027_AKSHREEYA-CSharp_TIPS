using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

/// <summary>
/// Serializes objects using a dynamically generated method.
/// </summary>
public static class EmitSerializer
{
    /// <summary>
    /// Creates a dynamic serializer for the specified type.
    /// </summary>
    /// <param name="type">The type of object to serialize.</param>
    /// <returns>Returns function of object and string</returns>
    public static Func<object, string> CreateSerializer(Type type)
    {
        DynamicMethod method = new DynamicMethod(
            "SerializeObject",
            typeof(string),
            new[] { typeof(object) },
            typeof(EmitSerializer).Module,
            true);

        ILGenerator il = method.GetILGenerator();
        LocalBuilder builder = il.DeclareLocal(typeof(StringBuilder));
        il.Emit(OpCodes.Newobj, typeof(StringBuilder).GetConstructor(Type.EmptyTypes) !);
        il.Emit(OpCodes.Stloc, builder);
        PropertyInfo[] properties = type.GetProperties();
        for (int i = 0; i < properties.Length; i++)
        {
            PropertyInfo property = properties[i];

            if (i > 0)
            {
                il.Emit(OpCodes.Ldloc, builder);
                il.Emit(OpCodes.Ldstr, ", ");
                il.Emit(OpCodes.Callvirt, typeof(StringBuilder).GetMethod(nameof(StringBuilder.Append), new[] { typeof(string) }) !);
                il.Emit(OpCodes.Pop);
            }

            il.Emit(OpCodes.Ldloc, builder);
            il.Emit(OpCodes.Ldstr, property.Name + "=");
            il.Emit(OpCodes.Callvirt, typeof(StringBuilder).GetMethod(nameof(StringBuilder.Append), new[] { typeof(string) }) !);
            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ldloc, builder);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, type);
            il.Emit(OpCodes.Callvirt, property.GetMethod!);
            if (property.PropertyType.IsValueType)
            {
                il.Emit(OpCodes.Box, property.PropertyType);
            }

            il.Emit(OpCodes.Call, typeof(EmitSerializer).GetMethod(nameof(AppendValue), BindingFlags.NonPublic | BindingFlags.Static) !);
            il.Emit(OpCodes.Pop);
        }

        il.Emit(OpCodes.Ldloc, builder);
        il.Emit(OpCodes.Callvirt, typeof(object).GetMethod(nameof(ToString)) !);
        il.Emit(OpCodes.Ret);
        return (Func<object, string>)method.CreateDelegate(typeof(Func<object, string>));
    }

    /// <summary>
    /// Appends a value to the supplied StringBuilder.
    /// </summary>
    private static StringBuilder AppendValue(StringBuilder builder, object? value)
    {
        return builder.Append(value);
    }
}
