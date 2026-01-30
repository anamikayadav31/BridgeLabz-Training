using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class FirstMissingPositive
    {
           public static void Main(string[] args)
            {
                Console.Write("Enter number of elements: ");
                int n = int.Parse(Console.ReadLine());

                int[] arr = new int[n];

                Console.WriteLine("Enter array elements:");
                for (int i = 0; i < n; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }

                int missing = FindFirstMissingPositive(arr, n);
                Console.WriteLine("First Missing Positive Integer is: " + missing);
            }

            // Linear search based approach
            static int FindFirstMissingPositive(int[] arr, int n)
            {
                // Extra array to mark presence
                bool[] present = new bool[n + 1];

                // Mark positive numbers
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] > 0 && arr[i] <= n)
                    {
                        present[arr[i]] = true;
                    }
                }

                // Find first missing positive
                for (int i = 1; i <= n; i++)
                {
                    if (!present[i])
                    {
                        return i;
                    }
                }

                return n + 1;
            }
        }

    }

