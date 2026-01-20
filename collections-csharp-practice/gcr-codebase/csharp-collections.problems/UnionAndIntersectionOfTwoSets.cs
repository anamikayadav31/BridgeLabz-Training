using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{
    internal class UnionAndIntersectionOfTwoSets
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

            // Create copies so original sets remain unchanged
            HashSet<int> union = new HashSet<int>(set1);
            HashSet<int> intersection = new HashSet<int>(set1);

            // Union operation
            union.UnionWith(set2);

            // Intersection operation
            intersection.IntersectWith(set2);

            Console.WriteLine("\nUnion:");
            Console.WriteLine(string.Join(", ", union));

            Console.WriteLine("Intersection:");
            Console.WriteLine(string.Join(", ", intersection));
        }
    }

}
