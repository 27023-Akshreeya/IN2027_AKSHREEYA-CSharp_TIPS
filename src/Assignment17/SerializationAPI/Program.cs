using System.Diagnostics;

/// <summary>
/// Entry point of this application
/// </summary>
internal class Program
{
    private static void Main()
    {
        Student student = new Student
        {
            Id = 1,
            Name = "Akshreeya",
            Marks = 95.5,
        };
        string reflectionResult = ReflectionSerializer.Serialize(student);
        Func<object, string> serializer = EmitSerializer.CreateSerializer(typeof(Student));
        string emitResult = serializer(student);
        Console.WriteLine($"Reflection Output: {reflectionResult}");
        Console.WriteLine($"\nReflection.Emit Output: {emitResult}");
        Console.WriteLine($"\nOutputs match: {reflectionResult == emitResult}");
        const int iterations = 100_000;
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            ReflectionSerializer.Serialize(student);
        }

        stopwatch.Stop();
        Console.WriteLine($"\nReflection time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Restart();
        for (int i = 0; i < iterations; i++)
        {
            serializer(student);
        }

        stopwatch.Stop();
        Console.WriteLine($"Reflection.Emit time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
