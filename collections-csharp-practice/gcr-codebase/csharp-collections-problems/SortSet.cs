//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.Collections.collections_problems
//{
//    internal class SortSet
//    {
    
//        static void Main()
//        {
//            Console.WriteLine("Enter elements of the set (space separated):");
//            string[] input = Console.ReadLine().Split(' ');

//            HashSet<int> set = new HashSet<int>();

//            // Add elements to the HashSet
//            foreach (string item in input)
//            {
//                set.Add(int.Parse(item));
//            }

//            // Convert HashSet to List
//            List<int> sortedList = new List<int>(set);

//            // Sort the list in ascending order
//            sortedList.Sort();

//            Console.WriteLine("Sorted List:");
//            Console.WriteLine(string.Join(", ", sortedList));
//        }
//    }

//}
