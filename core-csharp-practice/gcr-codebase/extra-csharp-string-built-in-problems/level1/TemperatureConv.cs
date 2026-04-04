using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class TemperatureConv
    {



        public static void Main(string[] args)
        {
            // Ask user for temperature value
            Console.Write("Enter temperature val ");
            double temp = double.Parse(Console.ReadLine());

            // Ask user for conversion choice
            Console.Write("Convert to (C for Celsius, F for Fahrenheit) ");
            string choice = Console.ReadLine().ToUpper();

            // Perform conversion based on choice
            if (choice == "C")
            {
                double celsius = FahrenheitToCelsius(temp);
                Console.WriteLine(temp + "°F is " + celsius + "°C");
            }
            else if (choice == "F")
            {
                double fahrenheit = CelsiusToFahrenheit(temp);
                Console.WriteLine(temp + "°C is " + fahrenheit + "°F");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        // create a function to convert Fahrenheit to Celsius
        static double FahrenheitToCelsius(double f)
        {
            return (f - 32) * 5 / 9;
        }

        // create a function to convert Celsius to Fahrenheit
        static double CelsiusToFahrenheit(double c)
        {
            return (c * 9 / 5) + 32;
        }
    }
}

