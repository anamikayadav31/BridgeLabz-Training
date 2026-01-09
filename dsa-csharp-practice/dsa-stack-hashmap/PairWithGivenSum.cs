using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class PairWithGivenSum
    {
   

        static bool HasPair(int[] arr, int n, int target)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int complement = target - arr[i];

                if (set.Contains(complement))
                {
                    Console.WriteLine($"Pair found: {arr[i]} + {complement} = {target}");
                    return true;
                }

                set.Add(arr[i]);
            }

            return false;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            Console.Write("Enter target sum: ");
            int target = int.Parse(Console.ReadLine());

            if (!HasPair(arr, n, target))
                Console.WriteLine("No such pair exists.");
        }
    }

}
