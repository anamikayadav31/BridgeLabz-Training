using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class ShortTallMid
    {


        public  static void Main(string[] args)
        {
            int[] heights = new int[11];
            Random rand = new Random();

            // Assign random heights between 150 and 250 cm
            for (int i = 0; i < heights.Length; i++)
            {
                heights[i] = rand.Next(150, 251); // 251 because upper bound is exclusive
            }

            // Display player heights
            Console.WriteLine("Player Heights (in cm):");
            foreach (int height in heights)
            {
                Console.Write(height + " ");
            }
            Console.WriteLine("\n");

            // Calculate and display results
            int sum = CalculateSum(heights);
            double mean = CalculateMean(heights);
            int shortest = FindShortest(heights);
            int tallest = FindTallest(heights);

            Console.WriteLine("Sum of heights: " + sum + " cm");
            Console.WriteLine("Mean height: " + mean + " cm");
            Console.WriteLine("Shortest height: " + shortest + " cm");
            Console.WriteLine("Tallest height: " + tallest + " cm");
        }

        // Method to calculate sum of all elements in the array
        static int CalculateSum(int[] arr)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }

        // Method to calculate mean height
        static double CalculateMean(int[] arr)
        {
            int sum = CalculateSum(arr);
            return (double)sum / arr.Length;
        }

        // Method to find the shortest height
        static int FindShortest(int[] arr)
        {
            int min = arr[0];
            foreach (int num in arr)
            {
                if (num < min)
                    min = num;
            }
            return min;
        }

        // Method to find the tallest height
        static int FindTallest(int[] arr)
        {
            int max = arr[0];
            foreach (int num in arr)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }
    }
}
