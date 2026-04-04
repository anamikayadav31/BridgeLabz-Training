using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.dataStructures.timeAndSpaceComplexity
{
    internal class SearchTarget
    {
        // Linear Search: checks elements one by one
        static int LinearSearch(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                    return i;   // element found
            }
            return -1;          // element not found
        }

        // Binary Search
        static int BinarySearch(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (arr[mid] == key)
                    return mid;
                else if (arr[mid] < key)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter element to search: ");
            int key = int.Parse(Console.ReadLine());

            Stopwatch sw = new Stopwatch();

            // Linear Search timing
            sw.Start();
            int linearResult = LinearSearch(arr, key);
            sw.Stop();

            Console.WriteLine("\nLinear Search Result:");
            Console.WriteLine(linearResult == -1 ? "Element not found" : "Element found at index " + linearResult);
            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds + " ms");

            // Sort array before Binary Search
            Array.Sort(arr);

            // Binary Search timing
            sw.Restart();
            int binaryResult = BinarySearch(arr, key);
            sw.Stop();

            Console.WriteLine("\nBinary Search Result:");
            Console.WriteLine(binaryResult == -1 ? "Element not found": "Element found at index " + binaryResult);
            Console.WriteLine("Time taken: " + sw.ElapsedMilliseconds + " ms");

            Console.WriteLine("\nConclusion:");
            Console.WriteLine("Binary Search is faster for large sorted data.");
        }
    }

}

