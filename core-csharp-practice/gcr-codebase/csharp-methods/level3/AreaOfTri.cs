using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class AreaOfTri
    {
        public static void Main(string[] args)
        {
            // Sample points
            double x1 = 2, y1 = 4;
            double x2 = 4, y2 = 6;
            double x3 = 6, y3 = 8;

            Console.WriteLine($"Points: A({x1},{y1}), B({x2},{y2}), C({x3},{y3})");

            // Check using slope
            bool slopeResult =  AreCollinearBySlope(x1, y1, x2, y2, x3, y3);
            Console.WriteLine("Collinear by slope method? " + slopeResult);

            // Check using area
            bool areaResult = AreCollinearByArea(x1, y1, x2, y2, x3, y3);
            Console.WriteLine("Collinear by area method? " + areaResult);
        }


        // Check collinear using slope method
        public static bool AreCollinearBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            // Handle vertical lines to avoid division by zero
            if ((x2 - x1) == 0 && (x3 - x2) == 0)
                return true;
            if ((x2 - x1) == 0 || (x3 - x2) == 0)
                return false;

            double slopeAB = (y2 - y1) / (x2 - x1);
            double slopeBC = (y3 - y2) / (x3 - x2);
            double slopeAC = (y3 - y1) / (x3 - x1);

            return slopeAB == slopeBC && slopeBC == slopeAC;
        }

        // Check collinear using area of triangle
        public static bool AreCollinearByArea(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
            return area == 0;
        }
    }

   


}

