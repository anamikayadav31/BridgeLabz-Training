using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
        internal class LongestConsecutiveSequence
        {
            public static int FindLongestSequence(int[] arr, int n)
            {
                HashSet<int> set = new HashSet<int>();

                // Store all elements in hash set
                for (int i = 0; i < n; i++)
                {
                    set.Add(arr[i]);
                }

                int longest = 0;

                // Check each element
                for (int i = 0; i < n; i++)
                {
                    int current = arr[i];

                    // Check if it is start of a sequence
                    if (!set.Contains(current - 1))
                    {
                        int count = 1;

                        // Count consecutive numbers
                        while (set.Contains(current + count))
                        {
                            count++;
                        }

                        // Update longest length
                        if (count > longest)
                        {
                            longest = count;
                        }
                    }
                }

                return longest;
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

                int result = FindLongestSequence(arr, n);

                Console.WriteLine("Length of longest consecutive sequence: " + result);
            }
        }
    }


