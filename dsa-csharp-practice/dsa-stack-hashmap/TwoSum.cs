using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class TwoSum
    {
    

        static void FindTwoSum(int[] nums, int target)
        {
            // Dictionary to store value -> index
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // Check if complement exists
                if (map.ContainsKey(complement))
                {
                    Console.WriteLine($"Indices: {map[complement]}, {i}");
                    return;
                }

                // Store current value with index
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }

            Console.WriteLine("No two sum solution found.");
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter target sum: ");
            int target = int.Parse(Console.ReadLine());

            FindTwoSum(nums, target);
        }
    }

}
