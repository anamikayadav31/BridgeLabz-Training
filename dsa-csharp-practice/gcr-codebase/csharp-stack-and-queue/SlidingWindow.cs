using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    internal class SlidingWindow
    {
            public static void FindMaxInWindows(int[] arr, int n, int k)
            {
                // Deque to store indices
                LinkedList<int> deque = new LinkedList<int>();

                // Process first k elements
                for (int i = 0; i < k; i++)
                {
                    // Remove smaller elements from back
                    while (deque.Count > 0 && arr[deque.Last.Value] <= arr[i])
                    {
                        deque.RemoveLast();
                    }

                    deque.AddLast(i);
                }

                Console.WriteLine("\nMaximum in each sliding window:");

                // Process remaining elements
                for (int i = k; i < n; i++)
                {
                    // Front of deque has max of previous window
                    Console.Write(arr[deque.First.Value] + " ");

                    // Remove elements out of this window
                    while (deque.Count > 0 && deque.First.Value <= i - k)
                    {
                        deque.RemoveFirst();
                    }

                    // Remove smaller elements from back
                    while (deque.Count > 0 && arr[deque.Last.Value] <= arr[i])
                    {
                        deque.RemoveLast();
                    }

                    deque.AddLast(i);
                }

                // Print max of last window
                Console.Write(arr[deque.First.Value]);
            }

            public static void Main(string[] args)
            {
                Console.Write("Enter number of elements: ");
                int n = int.Parse(Console.ReadLine());

                int[] arr = new int[n];

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter element " + (i + 1) + ": ");
                    arr[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("Enter window size k: ");
                int k = int.Parse(Console.ReadLine());

                FindMaxInWindows(arr, n, k);
            }
        }
    }



