using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    internal class TwoSum
    {
            public static int[] FindTwoSum(int[] arr, int n, int target)
            {
                // Dictionary stores value and its index
                Dictionary<int, int> map = new Dictionary<int, int>();

                for (int i = 0; i < n; i++)
                {
                    int required = target - arr[i];

                    // Check if required value exists
                    if (map.ContainsKey(required))
                    {
                        return new int[] { map[required], i };
                    }

                    // Store current value with its index
                    if (!map.ContainsKey(arr[i]))
                    {
                        map[arr[i]] = i;
                    }
                }

                return new int[] { -1, -1 };
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

                Console.Write("Enter target sum: ");
                int target = int.Parse(Console.ReadLine());

                int[] result = FindTwoSum(arr, n, target);

                if (result[0] == -1)
                {
                    Console.WriteLine("No valid pair found");
                }
                else
                {
                    Console.WriteLine("Indices: " + result[0] + " and " + result[1]);
                }
            }
        }
    }


