using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class TempConversionMethods



    {
        public static void Main(string[] args)
        {//call methods 
            Console.WriteLine("Fahrenheit to Celsius: " + ConvertFahrenheitToCelsius(98.6));
            Console.WriteLine("Celsius to Fahrenheit: " + ConvertCelsiusToFahrenheit(37));
            Console.WriteLine("Pounds to Kilograms: " +  ConvertPoundsToKilograms(150));
            Console.WriteLine("Kilograms to Pounds: " + ConvertKilogramsToPounds(68));
            Console.WriteLine("Gallons to Liters: " + ConvertGallonsToLiters(5));
            Console.WriteLine("Liters to Gallons: " + ConvertLitersToGallons(10));
        }
        // create method to convert Fahrenheit to Celsius
        public static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            double fahrenheit2celsius = (fahrenheit - 32) * 5 / 9;
            return fahrenheit2celsius;
        }

        // create method to convert Celsius to Fahrenheit
        public static double ConvertCelsiusToFahrenheit(double celsius)
        {
            double celsius2fahrenheit = (celsius * 9 / 5) + 32;
            return celsius2fahrenheit;
        }

        // create method to convert pounds to kilograms
        public static double ConvertPoundsToKilograms(double pounds)
        {
            double pounds2kilograms = 0.453592;
            return pounds * pounds2kilograms;
        }

        // create method to convert kilograms to pounds
        public static double ConvertKilogramsToPounds(double kilograms)
        {
            double kilograms2pounds = 2.20462;
            return kilograms * kilograms2pounds;
        }

        // create method to convert gallons to liters
        public static double ConvertGallonsToLiters(double gallons)
        {
            double gallons2liters = 3.78541;
            return gallons * gallons2liters;
        }

        // create method to convert liters to gallons
        public static double ConvertLitersToGallons(double liters)
        {
            double liters2gallons = 0.264172;
            return liters * liters2gallons;
        }
    }
}

       




