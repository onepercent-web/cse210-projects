using System;

class Program
{
    static void Main(string[] args)
    {
        // List for store shapes
        List<Shape> shapes = new List<Shape>();

        // Create a new Square object and add it to the list
        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        // Create a new Rectangle object and add it to the list
        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        // Create a new Circle object and add it to the list  
        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        // Iterate over each shape in the list
        foreach (Shape s in shapes)
        {
            // Get the color of the shape
            string color = s.GetColor();

            // Calculate the area of the shape
            double area = s.GetArea();
    
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}