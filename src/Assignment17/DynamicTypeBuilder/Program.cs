using System.Reflection;
using System.Reflection.Emit;

namespace DynamicTypeBuilder;

/// <summary>
/// Provides an entry point for creating and interacting with a dynamic type at runtime using reflection emit.
/// </summary>
/// <remarks>Demonstrates defining a dynamic assembly, module, type, property, and method, and shows how to
/// instantiate and use the generated type.</remarks>
internal class Program
{
    private static void Main(string[] args)
    {
        AssemblyName assemblyName = new ("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("Person", TypeAttributes.Public);
        FieldBuilder fieldBuilder = typeBuilder.DefineField("_name", typeof(string), FieldAttributes.Private);
        PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("Name", PropertyAttributes.None, typeof(string), null);
        MethodBuilder getMethod = typeBuilder.DefineMethod("get_Name", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, typeof(string), Type.EmptyTypes);
        ILGenerator getIL = getMethod.GetILGenerator();
        getIL.Emit(OpCodes.Ldarg_0);
        getIL.Emit(OpCodes.Ldfld, fieldBuilder);
        getIL.Emit(OpCodes.Ret);
        MethodBuilder setMethod = typeBuilder.DefineMethod("set_Name", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { typeof(string) });
        ILGenerator setIL = setMethod.GetILGenerator();
        setIL.Emit(OpCodes.Ldarg_0);
        setIL.Emit(OpCodes.Ldarg_1);
        setIL.Emit(OpCodes.Stfld, fieldBuilder);
        setIL.Emit(OpCodes.Ret);
        propertyBuilder.SetGetMethod(getMethod);
        propertyBuilder.SetSetMethod(setMethod);
        MethodBuilder greetMethod = typeBuilder.DefineMethod("SayHello", MethodAttributes.Public, typeof(void), Type.EmptyTypes);
        ILGenerator methodIL = greetMethod.GetILGenerator();
        methodIL.Emit(OpCodes.Ldstr, "Hello from dynamically created type!");
        methodIL.Emit(OpCodes.Call, typeof(Console).GetMethod(nameof(Console.WriteLine), new[] { typeof(string) }) !);
        methodIL.Emit(OpCodes.Ret);
        Type dynamicType = typeBuilder.CreateType() !;
        object instance = Activator.CreateInstance(dynamicType) !;
        dynamicType.GetProperty("Name")?.SetValue(instance, "Akshreeya");
        Console.WriteLine($"Name: {dynamicType.GetProperty("Name")?.GetValue(instance)}");
        dynamicType.GetMethod("SayHello")?.Invoke(instance, null);
    }
}