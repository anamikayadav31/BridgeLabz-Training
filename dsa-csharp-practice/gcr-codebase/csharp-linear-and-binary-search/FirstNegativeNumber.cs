using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class FirstNegativeNumber
    {
        public static void Main(string[] args)
        {
            // Ask user for array size
            Console.Write("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            // Take array elements from user
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element " + (i + 1) + ": ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            // Linear search to find first negative number
            for (int i = 0; i < n; i++)
            {
                // Check if number is negative
                if (arr[i] < 0)
                {
                    Console.WriteLine("First Negative Number: " + arr[i]);
                    return; // Stop after finding first negative
                }
            }

            // If no negative number found
            Console.WriteLine("No negative number found in the array");
        }
    }
}