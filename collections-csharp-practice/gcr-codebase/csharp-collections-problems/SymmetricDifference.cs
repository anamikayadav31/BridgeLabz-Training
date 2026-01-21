/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{
    internal class SymmetricDifference
    {
   

        static void Main()
        {
            Console.WriteLine("Enter elements of Set 1 (space separated):");
            string[] input1 = Console.ReadLine().Split(' ');

            Console.WriteLine("Enter elements of Set 2 (space separated):");
            string[] input2 = Console.ReadLine().Split(' ');

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            // Add elements to Set 1
            foreach (string item in input1)
            {
                set1.Add(int.Parse(item));
            }

            // Add elements to Set 2
            foreach (string item in input2)
            {
                set2.Add(int.Parse(item));
            }

            // Create a copy to preserve original sets
            HashSet<int> symmetricDifference = new HashSet<int>(set1);

            // Perform symmetric difference
            symmetricDifference.SymmetricExceptWith(set2);

            Console.WriteLine("\nSymmetric Difference:");
            Console.WriteLine(string.Join(", ", symmetricDifference));
        }
    }

}
*/