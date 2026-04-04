/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.classAndObject
{
    internal class CreateCircle
    {



        public static void Main(string[] args)
        {
            Console.Write("Enter the radius of the circle: ");
            double radius = double.Parse(Console.ReadLine());
            // Create Circle object
            Circle circle1 = new Circle(radius);

            // Print details directly using the object
            Console.WriteLine($"Area: {circle1.Area()}");
            Console.WriteLine($"Circumference: {circle1.Circumference()}");
        }

        class Circle
        {
            public double Radius;

            public Circle(double radius)
            {
                Radius = radius;
            }
            //calculate area
            public double Area()
            {
                return Math.PI * Radius * Radius;
            }

            public double Circumference()
            {
                return 2 * Math.PI * Radius;
            }
        }

    }
}
*/