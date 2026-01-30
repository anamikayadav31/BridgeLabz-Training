using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    internal class SubarraysWithZero
    {
            public static void FindZeroSumSubarrays(int[] arr, int n)
            {
                // Dictionary to store cumulative sum and list of indices
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

                int sum = 0;

                // Add sum 0 at index -1 
                map[0] = new List<int> { -1 };

                for (int i = 0; i < n; i++)
                {
                    sum = sum + arr[i];

                    // If sum already exists, zero-sum subarray found
                    if (map.ContainsKey(sum))
                    {
                        foreach (int startIndex in map[sum])
                        {
                            Console.WriteLine("Zero sum subarray found from index " + (startIndex + 1) + " to " + i);
                        }
                    }

                    // Add current index to map
                    if (!map.ContainsKey(sum))
                    {
                        map[sum] = new List<int>();
                    }

                    map[sum].Add(i);
                }
            }

            public static void Main(string[] args)
            {
                Console.Write("Enter number of elements: ");
                int n = int.Parse(Console.ReadLine());

                int[] arr = new int[n];

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter element " + i + ": ");
                    arr[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("\nZero Sum Subarrays:");
                FindZeroSumSubarrays(arr, n);
            }
        }
    }



