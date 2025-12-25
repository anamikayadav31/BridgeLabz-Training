using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class ComputeWildChillTemp
    {
        public static void Main(string[] args)
        {//ask user to input temperature
             double temperature =  double.Parse(Console.ReadLine());
            //ask user to input wind speed
             double  windSpeed = double.Parse(Console.ReadLine());
            //call method
            Console.WriteLine(CalculateWindChill(temperature,windSpeed));
        }
        // Method to calculate wind chill temperature
        public static double CalculateWindChill(double temperature, double windSpeed)
        {//   // Wind chill formula
            double windChill= 35.74 + 0.6215 * temperature + (0.4275 * temperature - 35.75) * Math.Pow(windSpeed,0.16);
            return windChill;
        }

    }
}
