using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class RandomNumber
    {


        public static void Main(string[] args)
        {
            int size = 5;

            // generate random numbers
            int[] numbers = Generate4DigitRandomArray(size);

            // print generated numbers
            Console.WriteLine("Generated 4-digit random numbers:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // calculate average, min, max
            double[] results = FindAverageMinMax(numbers);

            Console.WriteLine("\nAverage: " + results[0]);
            Console.WriteLine("Minimum: " + results[1]);
            Console.WriteLine("Maximum: " + results[2]);
        }

        // create method to generate array of 4-digit random numbers
        public static int[] Generate4DigitRandomArray(int size)
        {
            int[] arr = new int[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(1000, 10000);
            }

            return arr;
        }

        // create method to find average, minimum, and maximum of an array
        public static double[] FindAverageMinMax(int[] numbers)
        {
            int min = numbers[0];
            int max = numbers[0];
            int sum = 0;

            foreach (int num in numbers)
            {
                sum += num;
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            double average = (double)sum / numbers.Length;

            return new double[] { average, min, max };
        }

    }
}

   
