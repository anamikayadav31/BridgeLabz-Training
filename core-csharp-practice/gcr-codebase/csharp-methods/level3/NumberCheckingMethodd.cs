using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class NumberCheckingMethodd
    {
       

        public static void Main(string[] args)
        {//creates array
            int[] heights = new int[11]; 

            Random rand = new Random(); 


            // fill array with random heights between 150 and 250 cm
            for (int i = 0; i < heights.Length; i++)
            {
                heights[i] = rand.Next(150, 251); 

            }

            // print all player heights
            Console.WriteLine("Player Heights (in cm):");
            foreach (int height in heights)
            {
                Console.Write(height + " ");
            }
            Console.WriteLine("\n");

            // Call methods to calculate sum, mean, shortest and tallest heights
            int sum = CalculateSum(heights);
            double mean = CalculateMean(heights);
            int shortest = FindShortest(heights);
            int tallest = FindTallest(heights);

            // print results
            Console.WriteLine("Sum of heights: " + sum + " cm");
            Console.WriteLine("Mean height: " + mean + " cm");
            Console.WriteLine("Shortest height: " + shortest + " cm");
            Console.WriteLine("Tallest height: " + tallest + " cm");
        }

        // craete method to calculate sum of all heights
        static int CalculateSum(int[] arr)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                sum += num; // Add each height to sum
            }
            return sum;
        }

        // create method to calculate mean height
        static double CalculateMean(int[] arr)
        {
            int sum = CalculateSum(arr);
            return (double)sum / arr.Length; 

        }

        // create method to find shortest height
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

        // craete method to find tallest height
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

