/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{
    internal class RemoveDuplicateProgram
    {


        static List<int> RemoveDuplicates(List<int> list)
        {
            HashSet<int> seen = new HashSet<int>();
            List<int> result = new List<int>();

            // Iterate through the list
            foreach (int item in list)
            {
                // Add only if not already seen
                if (!seen.Contains(item))
                {
                    seen.Add(item);
                    result.Add(item);
                }
            }

            return result;
        }

        static void Main()
        {
            Console.WriteLine("Enter numbers (space separated):");
            string[] input = Console.ReadLine().Split(' ');

            List<int> numbers = new List<int>();

            // Convert input strings to integers
            foreach (string item in input)
            {
                numbers.Add(int.Parse(item));
            }

            List<int> uniqueList = RemoveDuplicates(numbers);

            Console.WriteLine("List after removing duplicates:");
            Console.WriteLine(string.Join(", ", uniqueList));
        }
    }
}*/