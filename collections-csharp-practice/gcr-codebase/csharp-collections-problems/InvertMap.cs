//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.Collections.collections_problems
//{
//    internal class InvertMap
//    {



//        static void Main()
//        {
//            // Ask the user how many entries they want to input
//            Console.Write("How many key-value pairs do you want to enter? ");
//            int n = int.Parse(Console.ReadLine());

//            // dictionary
            
//            Dictionary<string, int> original = new Dictionary<string, int>();

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter key #{i + 1}: ");
//                string key = Console.ReadLine();

//                Console.Write($"Enter value for {key} (integer): ");
//                int value = int.Parse(Console.ReadLine());

//                original[key] = value;
//            }

//            // Dictionary to store the inverted map

//            Dictionary<int, List<string>> inverted = new Dictionary<int, List<string>>();

//            foreach (var kvp in original)
//            {
//                if (!inverted.ContainsKey(kvp.Value))
//                {
//                    // Initialize a new list
//                    inverted[kvp.Value] = new List<string>();
//                }
//                inverted[kvp.Value].Add(kvp.Key); // Add the key to list
//            }

//            // Display the inverted dictionary
//            Console.WriteLine("\nInverted Dictionary:");
//            foreach (var kvp in inverted)
//            {
//                Console.WriteLine($"{kvp.Key} : [{string.Join(", ", kvp.Value)}]");
//            }
//        }
//    }
//}