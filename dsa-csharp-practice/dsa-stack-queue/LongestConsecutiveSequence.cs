/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class LongestConsecutiveSequence
    {
        

        static int FindLongestSequence(int[] arr, int n)
        {
          

            HashSet<int> set = new HashSet<int>();

            // Insert all array elements into the HashSet
            // This removes duplicates automatically
            foreach (int num in arr)
            {
                set.Add(num);
            }

            int longest = 0; // Stores the maximum sequence length found

            // Traverse each element in the array
            foreach (int num in arr)
            {
               

                if (!set.Contains(num - 1))
                {
                    int current = num; // Current number in the sequence
                    int count = 1;     // Length of the current sequence



                    while (set.Contains(current + 1))
                    {
                        current++; // Move to next number
                        count++;   // Increase sequence length
                    }

                    // update longest sequence length if needed
                    longest = Math.Max(longest, count);
                }
            }

            // return the longest consecutive sequence length
            return longest;
        }

        static void Main()
        {
            // Read array size from user
            Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            // Read array elements
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            // Call function and print result
            int result = FindLongestSequence(arr, n);
            Console.WriteLine("Longest consecutive sequence length: " + result);
        }
    }

}

*/