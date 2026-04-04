using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class ConversionsMethod
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Kilometers to Miles: " + ConvertKmToMiles(10));
            Console.WriteLine("Miles to Kilometers: " +ConvertMilesToKm(5));
            Console.WriteLine("Meters to Feet: " + ConvertMetersToFeet(20));
            Console.WriteLine("Feet to Meters: " + ConvertFeetToMeters(50));
        }

        // create method to convert kilometers to miles
        public static double ConvertKmToMiles(double km)
        {
            double km2miles = 0.621371;
            return km * km2miles;
        }

        // create method to convert miles to kilometers
        public static double ConvertMilesToKm(double miles)
        {
            double miles2km = 1.60934;
            return miles * miles2km;
        }

        // create method to convert meters to feet
        public static double ConvertMetersToFeet(double meters)
        {
            double meters2feet = 3.28084;
            return meters * meters2feet;
        }

        // create method to convert feet to meters
        public static double ConvertFeetToMeters(double feet)
        {
            double feet2meters = 0.3048;
            return feet * feet2meters;
        }
    }





}
