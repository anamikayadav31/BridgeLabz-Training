using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class FirstLastOccurrence
    {       
        public static void Main(string[] args)
        {
            // Read array size
            Console.Write("Enter size of sorted array: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            // Read array elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element " + (i + 1) + ": ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            // Read target element
            Console.Write("Enter target element: ");
            int target = int.Parse(Console.ReadLine());

            int first = -1;
            int last = -1;

            // Find first occurrence
            int low = 0, high = n - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == target)
                {
                    first = mid;
                   high = mid - 1; // Search left half for first occurrence
               }
                else if (arr[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            // Find last occurrence
            low = 0;
            high = n - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == target)
                {
                    last = mid;
                    low = mid + 1; // Search right half for last occurrence
                }
                else if (arr[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            if (first != -1)
            {
 
                Console.WriteLine("First occurrence at index: " + first);
                Console.WriteLine("Last occurrence at index: " + last);
            }
            else
            { 
                Console.WriteLine("Target not found in array");
            }
        }
    }

}
    

