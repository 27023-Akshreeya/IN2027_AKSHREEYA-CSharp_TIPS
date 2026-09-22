using System;
using System.Collections.Generic;
using PatternMatching;

namespace Assignments;

/// <summary>
/// Provides the entry point and shape detail display logic for the application.
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(10, 5),
            new Triangle(8, 4),
            null,
        };

            foreach (Shape shape in shapes)
            {
                DisplayShapeDetails(shape);
            }

            var square = new Square(6);

            // DisplayShapeDetails(square);
            // this will throw a compile time error stating that "Argument 1: cannot convert from 'PatternMatching.Square' to 'PatternMatching.Shape'"
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DisplayShapeDetails(Shape shape)
    {
        switch (shape)
        {
            case null:
                Console.WriteLine("Shape is null.");
                break;
            case Circle circle:
                Console.WriteLine($"Shape: Circle\nRadius: {circle.Radius}\nArea: {circle.CalculateArea()}");
                break;
            case Rectangle rectangle:
                Console.WriteLine($"Shape: Rectangle\nLength: {rectangle.Length}\nWidth: {rectangle.Width}\nArea: {rectangle.CalculateArea()}");
                break;
            case Triangle triangle:
                Console.WriteLine($"Shape: Triangle\nBase: {triangle.Base}\nHeight: {triangle.Height}\nArea: {triangle.CalculateArea()}");
                break;
            default:
                Console.WriteLine("Unknown shape.");
                break;
        }
    }
}