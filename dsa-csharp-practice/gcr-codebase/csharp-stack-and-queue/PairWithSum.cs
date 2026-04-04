using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    internal class PairWithSum
    {
            public static bool HasPairWithSum(int[] arr, int n, int target)
            {
                // HashMap to store visited elements
                Dictionary<int, bool> visited = new Dictionary<int, bool>();

                for (int i = 0; i < n; i++)
                {
                    int required = target - arr[i];

                    // Check if required value is already visited
                    if (visited.ContainsKey(required))
                    {
                        Console.WriteLine("Pair found: " + arr[i] + " and " + required);
                        return true;
                    }

                    // Store current element
                    if (!visited.ContainsKey(arr[i]))
                    {
                        visited[arr[i]] = true;
                    }
                }

                return false;
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

                bool found = HasPairWithSum(arr, n, target);

                if (!found)
                {
                    Console.WriteLine("No pair found with the given sum");
                }
            }
        }
    }
