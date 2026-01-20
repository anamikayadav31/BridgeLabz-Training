using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{



    class FrequencyProgram
    {
        // Method to calculate frequency of each string
        static Dictionary<string, int> FindFrequency(List<string> items)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            // Count each element
            foreach (string item in items)
            {
                if (frequency.ContainsKey(item))
                {
                    frequency[item]++; // Increase count if already exists
                }
                else
                {
                    frequency[item] = 1; // Add new element with count 1
                }
            }

            return frequency;
        }

        static void Main()
        {
            Console.WriteLine("Enter strings (space separated):");
            string[] input = Console.ReadLine().Split(' ');

            List<string> items = new List<string>(input);

            // Get frequency dictionary
            Dictionary<string, int> result = FindFrequency(items);

            Console.WriteLine("Element Frequencies:");
            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}