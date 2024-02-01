using System;
using System.Collections.Generic;

// Base class Shape
class Shape
{
    private string color;

    // Constructor
    public Shape(string color)
    {
        this.color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return color;
    }

    // Virtual method for calculating area
    public virtual double GetArea()
    {
        return 0.0;
    }
}

// Derived class Square
class Square : Shape
{
    private double side;

    // Constructor
    public Square(string color, double side) : base(color)
    {
        this.side = side;
    }

    // Override GetArea method
    public override double GetArea()
    {
        return side * side;
    }
}

// Derived class Rectangle
class Rectangle : Shape
{
    private double length;
    private double width;

    // Constructor
    public Rectangle(string color, double length, double width) : base(color)
    {
        this.length = length;
        this.width = width;
    }

    // Override GetArea method
    public override double GetArea()
    {
        return length * width;
    }
}

// Derived class Circle
class Circle : Shape
{
    private double radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    // Override GetArea method
    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

class Program
{
    static void Main()
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Add instances of different shapes to the list
        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));

        // Iterate through the list and display color and area for each shape
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}
