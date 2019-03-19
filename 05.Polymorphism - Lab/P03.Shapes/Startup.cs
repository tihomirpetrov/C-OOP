namespace Shapes
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double radius = double.Parse(Console.ReadLine());

            Shape circle = new Circle(radius);
            Shape rectangle = new Rectangle(height, width);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());

        }
    }
}