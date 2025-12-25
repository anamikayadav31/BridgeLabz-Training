using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class EuclidianDis
    {

        public static void Main(string[] args)
        {
            // Take input for two points
            Console.Write("Enter x1: ");
            double x1 = double.Parse(Console.ReadLine());

            Console.Write("Enter y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.Write("Enter x2: ");
            double x2 = double.Parse(Console.ReadLine());

            Console.Write("Enter y2: ");
            double y2 = double.Parse(Console.ReadLine());

            // Calculate Euclidean distance
            double distance = EuclideanDistance(x1, y1, x2, y2);
            Console.WriteLine($"\nEuclidean Distance: {distance:F2}");

            // Calculate equation of line
            double[] line = LineEquation(x1, y1, x2, y2);
            Console.WriteLine($"Equation of line: y = {line[0]:F2}x + {line[1]:F2}");
        }

        // Method to calculate Euclidean distance
        public static double EuclideanDistance(double x1, double y1, double x2, double y2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }

        // Method to calculate equation of line (y = m*x + b)
        public static double[] LineEquation(double x1, double y1, double x2, double y2)
        {
            double m = (y2 - y1) / (x2 - x1);  // slope
            double b = y1 - m * x1;           // y-intercept
            return new double[] { m, b };
        }
    }




}
