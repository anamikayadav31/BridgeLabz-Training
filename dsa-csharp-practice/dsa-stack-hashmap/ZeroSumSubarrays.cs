using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class ZeroSumSubarrays
    {
   

        static void FindZeroSumSubarrays(int[] arr, int n)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            int sum = 0;

            // Sum 0 occurs before array starts
            map[0] = new List<int> { -1 };

            for (int i = 0; i < n; i++)
            {
                sum += arr[i];

                if (map.ContainsKey(sum))
                {
                    foreach (int startIndex in map[sum])
                    {
                        Console.WriteLine($"zerosum subarray found from index {startIndex + 1} to {i}");
                    }
                    map[sum].Add(i);
                }
                else
                {
                    map[sum] = new List<int> { i };
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            FindZeroSumSubarrays(arr, n);
        }
    }

}
