using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class UnitConvertor
    {
        public static void Main(string[] args)
        {//call methods
            Console.WriteLine("Yards to Feet: " + ConvertYardsToFeet(5));
            Console.WriteLine("Feet to Yards: " + ConvertFeetToYards(9));
            Console.WriteLine("Meters to Inches: " + ConvertMetersToInches(2));
            Console.WriteLine("Inches to Meters: " + ConvertInchesToMeters(50));
            Console.WriteLine("Inches to Centimeters: " + ConvertInchesToCentimeters(10));
        }

        // create method to convert yards to feet
        public static double ConvertYardsToFeet(double yards)
        {
            double yards2feet = 3;
            return yards * yards2feet;
        }

        // create method to convert feet to yards
        public static double ConvertFeetToYards(double feet)
        {
            double feet2yards = 0.333333;
            return feet * feet2yards;
        }

        // create method to convert  meters to inches
        public static double ConvertMetersToInches(double meters)
        {
            double meters2inches = 39.3701;
            return meters * meters2inches;
        }

        // create method to convert inches to meters
        public static double ConvertInchesToMeters(double inches)
        {
            double inches2meters = 0.0254;
            return inches * inches2meters;
        }

        // create method to convert inches to centimeters
        public static double ConvertInchesToCentimeters(double inches)
        {
            double inches2cm = 2.54;
            return inches * inches2cm;
        }
    }

   





}


