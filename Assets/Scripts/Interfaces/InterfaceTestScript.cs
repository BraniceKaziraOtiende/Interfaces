using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface script 
/// </summary>
public class InterfaceTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("====================================");
        Debug.Log("INTERFACE ASSIGNMENT - SHAPE TESTING");
        Debug.Log("====================================\n");

        // ========== TEST 1: TRAPEZIUM ==========
        Debug.Log("TEST 1: Creating and Testing Trapezium...");
        Trapezium trapezium = new Trapezium();
        trapezium.DisplayInfo();

        // Call Trapezium-specific method first
        trapezium.CalculateUnknownSides();

        // Call interface methods
        trapezium.CalculateArea();
        trapezium.CalculatePerimeter();
        Debug.Log(""); // Empty line for spacing


        // ========== TEST 2: CIRCLE ==========
        Debug.Log("TEST 2: Creating and Testing Circle...");
        Circle circle = new Circle();
        circle.DisplayInfo();

        // Call Circle-specific method first
        circle.CalculateRadius();

        // Call interface methods
        circle.CalculateArea();
        circle.CalculatePerimeter();
        Debug.Log(""); // Empty line for spacing


        // ========== TEST 3: NONAGON ==========
        Debug.Log("TEST 3: Creating and Testing Nonagon...");
        Nonagon nonagon = new Nonagon();
        nonagon.DisplayInfo();

        // Call Nonagon-specific method
        int sides = nonagon.CalculateNumberOfSides();

        // Call interface methods
        nonagon.CalculateArea();
        nonagon.CalculatePerimeter();
        Debug.Log(""); // Empty line for spacing


        // ========== BONUS: POLYMORPHISM DEMONSTRATION ==========
        Debug.Log("====================================");
        Debug.Log("BONUS: Demonstrating Polymorphism");
        Debug.Log("====================================\n");

        Debug.Log("Storing all shapes using IShape interface reference:");

        // Store all shapes in an array using interface type
        IShape[] shapes = new IShape[] { trapezium, circle, nonagon };

        Debug.Log($"Total shapes in array: {shapes.Length}\n");

        // Call interface methods on all shapes through polymorphism
        Debug.Log("Calling CalculateArea() on all shapes:");
        foreach (IShape shape in shapes)
        {
            shape.CalculateArea();
        }

        Debug.Log("\nCalling CalculatePerimeter() on all shapes:");
        foreach (IShape shape in shapes)
        {
            shape.CalculatePerimeter();
        }

        Debug.Log("\n====================================");
        Debug.Log("ALL TESTS COMPLETED SUCCESSFULLY!");
        Debug.Log("====================================");
    }

    // Update is called once per frame
    void Update()
    {
        // Not needed for this assignment
    }
}


/// <summary>
/// Common interface for all shapes
/// Contains only methods that are shared across ALL shape classes
/// Based on analysis: only CalculateArea() and CalculatePerimeter() 
/// appear in all three classes (Trapezium, Circle, Nonagon)
/// </summary>
public interface IShape
{
    // All shapes can calculate their area
    void CalculateArea();

    // All shapes can calculate their perimeter
    void CalculatePerimeter();
}


/// <summary>
/// Trapezium shape implementation of IShape interface
/// A trapezium has two parallel sides (bases) and two non-parallel sides
/// </summary>
public class Trapezium : IShape
{
    // Properties specific to trapezium
    private float baseA = 10f;      // First parallel side
    private float baseB = 6f;       // Second parallel side
    private float height = 4f;      // Perpendicular distance between bases
    private float sideC;            // First non-parallel side (unknown)
    private float sideD;            // Second non-parallel side (unknown)
    private float area;
    private float perimeter;

    // Method specific to Trapezium (not in interface)
    public void CalculateUnknownSides()
    {
        // Using Pythagorean theorem to calculate unknown sides
        // For a symmetric trapezium, the legs form right triangles with the height
        float baseDifference = Mathf.Abs(baseA - baseB) / 2f;
        sideC = Mathf.Sqrt((baseDifference * baseDifference) + (height * height));
        sideD = sideC; // Assuming symmetric trapezium

        Debug.Log($"Trapezium - Calculated Unknown Sides: Side C = {sideC:F2}, Side D = {sideD:F2}");
    }

    // Implement CalculateArea from IShape interface
    public void CalculateArea()
    {
        // Area of trapezium = ((base1 + base2) / 2) * height
        area = ((baseA + baseB) / 2f) * height;
        Debug.Log($"Trapezium - Area: {area:F2} square units");
    }

    // Implement CalculatePerimeter from IShape interface
    public void CalculatePerimeter()
    {
        // Make sure sides are calculated first
        if (sideC == 0 || sideD == 0)
        {
            CalculateUnknownSides();
        }

        // Perimeter = sum of all sides
        perimeter = baseA + baseB + sideC + sideD;
        Debug.Log($"Trapezium - Perimeter: {perimeter:F2} units");
    }

    // Helper method to display all info
    public void DisplayInfo()
    {
        Debug.Log("=== TRAPEZIUM ===");
        Debug.Log($"Base A: {baseA}, Base B: {baseB}, Height: {height}");
    }
}


/// <summary>
/// Circle shape implementation of IShape interface
/// A circle is defined by its radius
/// </summary>
public class Circle : IShape
{
    // Properties specific to circle
    private float radius;
    private float area;
    private float perimeter;

    // Constructor to initialize with area (then calculate radius)
    public Circle()
    {
        // Start with a known area and calculate radius from it
        area = 154f; // arbitrary starting area
        CalculateRadius();
    }

    // Method specific to Circle (not in interface)
    public void CalculateRadius()
    {
        // Calculate radius from area: r = sqrt(Area / π)
        radius = Mathf.Sqrt(area / Mathf.PI);
        Debug.Log($"Circle - Calculated Radius: {radius:F2} units");
    }

    // Implement CalculateArea from IShape interface
    public void CalculateArea()
    {
        // Area of circle = π * r²
        area = Mathf.PI * radius * radius;
        Debug.Log($"Circle - Area: {area:F2} square units");
    }

    // Implement CalculatePerimeter from IShape interface
    public void CalculatePerimeter()
    {
        // Perimeter (Circumference) of circle = 2 * π * r
        perimeter = 2f * Mathf.PI * radius;
        Debug.Log($"Circle - Perimeter (Circumference): {perimeter:F2} units");
    }

    // Helper method to display all info
    public void DisplayInfo()
    {
        Debug.Log("=== CIRCLE ===");
        Debug.Log($"Radius: {radius:F2}");
    }
}


/// <summary>
/// Nonagon shape implementation of IShape interface
/// A nonagon is a 9-sided polygon
/// </summary>
public class Nonagon : IShape
{
    // Properties specific to nonagon
    private float sideLength = 5f;  // Length of each side
    private int numberOfSides = 9;   // A nonagon always has 9 sides
    private float area;
    private float perimeter;

    // Method specific to Nonagon (not in interface)
    public int CalculateNumberOfSides()
    {
        Debug.Log($"Nonagon - Number of Sides: {numberOfSides}");
        return numberOfSides;
    }

    // Implement CalculateArea from IShape interface
    public void CalculateArea()
    {
        // Area of regular nonagon = (9/4) * s² * cot(π/9)
        // cot(x) = 1/tan(x)
        float cotangent = 1f / Mathf.Tan(Mathf.PI / 9f);
        area = (9f / 4f) * sideLength * sideLength * cotangent;
        Debug.Log($"Nonagon - Area: {area:F2} square units");
    }

    // Implement CalculatePerimeter from IShape interface
    public void CalculatePerimeter()
    {
        // Perimeter of nonagon = number of sides * side length
        perimeter = numberOfSides * sideLength;
        Debug.Log($"Nonagon - Perimeter: {perimeter:F2} units");
    }

    // Helper method to display all info
    public void DisplayInfo()
    {
        Debug.Log("=== NONAGON ===");
        Debug.Log($"Side Length: {sideLength}");
        Debug.Log($"Number of Sides: {numberOfSides}");
    }
}