using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class CircleClass
    {
        static void Main(string[] args)
        {
            // Using default constructor
            Circle defaultCircle = new Circle();
            Console.WriteLine("Default Circle:");
            Console.WriteLine("Radius: " + defaultCircle.Radius);
            Console.WriteLine("Area: " + defaultCircle.GetArea());
            Console.WriteLine("Circumference: " + defaultCircle.GetCircumference());
            Console.WriteLine();

            // Taking user input for radius
            Console.Write("Enter radius for a new circle: ");
            double userRadius = Convert.ToDouble(Console.ReadLine());

            // Using parameterized constructor
            Circle userCircle = new Circle(userRadius);
            Console.WriteLine("\nUser Circle:");
            Console.WriteLine("Radius: " + userCircle.Radius);
            Console.WriteLine("Area: " + userCircle.GetArea());
            Console.WriteLine("Circumference: " + userCircle.GetCircumference());

            
        }
    }


    class Circle
    {
        public double Radius;

        // Default constructor using constructor chaining
        public Circle() : this(1.0)  // Default radius = 1.0
        {
        }

        // Parameterized constructor
        public Circle(double radius)
        {
            Radius = radius;
        }

        // Optional: method to calculate area
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Optional: method to calculate circumference
        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }
    }


}
       




