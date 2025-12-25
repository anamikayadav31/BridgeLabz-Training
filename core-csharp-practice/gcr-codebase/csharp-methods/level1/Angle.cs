using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class Angle
    {
        public static void Main(string[] args)
        {
            //ask user to input angle
            Console.Write("Enter angle in degrees: ");
            double angle = double.Parse(Console.ReadLine());
            // Call method to calculate trigonometric functions
            double[] result = CalculateTrigonometricFunctions(angle);
            // Print results
            Console.WriteLine("Sine: " + result[0]);
            Console.WriteLine("Cosine: " + result[1]);
            Console.WriteLine("Tangent: " + result[2]);
        }
        // Method to calculate sine, cosine and tan
        public static double[] CalculateTrigonometricFunctions(double angle)
        {
            // Convert degrees to radians
            double radians = angle * Math.PI / 180;
            // Calculate trigonometric values
            double sine = Math.Sin(radians);
            double cosine = Math.Cos(radians);
            double tangent = Math.Tan(radians);
            // return result as an array
            return new double[] { sine, cosine, tangent };
        }


    }
}
