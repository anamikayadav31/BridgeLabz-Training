using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    internal class MeanOfHeight
    {
        public static void Main(string[] args)
        {
            // Create an array of size 11 
            double[] numbers = new double[11];
            //initialise sum with 0
            double sum = 0.0;
            //ask players to input their heights
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }
            //compute sum 
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            //compute mean
            double mean = sum / 11;
            //print mean
            Console.WriteLine("Mean is " + mean);
        }
    }
}
