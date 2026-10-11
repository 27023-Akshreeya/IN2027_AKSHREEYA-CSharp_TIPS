using System.Reflection;
using System.Reflection.Emit;

/// <summary>
/// Generates mock objects dynamically using Reflection.Emit.
/// </summary>
public class MockGenerator
{
    /// <summary>
    /// Creates a mock instance of the specified interface.
    /// </summary>
    /// <typeparam name="T">The interface type to mock.</typeparam>
    /// <returns>A dynamically generated mock instance.</returns>
    public static ICalculator CreateMockCalculator()
    {
        Type interfaceType = typeof(ICalculator);

        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicMockAssembly"), AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MockModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicMock", TypeAttributes.Public | TypeAttributes.Class);
        typeBuilder.AddInterfaceImplementation(interfaceType);
        foreach (MethodInfo method in interfaceType.GetMethods())
        {
            Type[] parameterTypes = method.GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();
            MethodBuilder methodBuilder =
                typeBuilder.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
                    method.ReturnType,
                    parameterTypes);

            ILGenerator il = methodBuilder.GetILGenerator();
            if (method.ReturnType == typeof(void))
            {
                il.Emit(OpCodes.Ret);
            }
            else if (method.ReturnType.IsValueType)
            {
                LocalBuilder local =
                    il.DeclareLocal(method.ReturnType);
                il.Emit(OpCodes.Ldloca_S, local);
                il.Emit(OpCodes.Initobj, method.ReturnType);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);
            }
            else
            {
                il.Emit(OpCodes.Ldnull);
                il.Emit(OpCodes.Ret);
            }

            typeBuilder.DefineMethodOverride(methodBuilder, method);
        }

        Type mockType = typeBuilder.CreateType() !;
        return (ICalculator)Activator.CreateInstance(mockType) !;
    }
}
