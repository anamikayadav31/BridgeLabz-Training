//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.Collections.collections_problems
//{
//    internal class ShoppingCart
//    {



//        static void Main()
//        {
//            // Dictionary to store product prices
//            Dictionary<string, double> productPrices = new Dictionary<string, double>();

//            // LinkedList to maintain order of added products
//            LinkedList<string> productOrder = new LinkedList<string>();

//            // Input products from user
//            Console.WriteLine("Enter number of products to add:");
//            int n = int.Parse(Console.ReadLine());

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write("Enter product name: ");
//                string name = Console.ReadLine();
//                Console.Write("Enter product price: ");
//                double price = double.Parse(Console.ReadLine());

//                // Add to dictionary and linked list
//                productPrices[name] = price;
//                productOrder.AddLast(name);
//            }

//            Console.WriteLine("\nProducts in the order added:");
//            foreach (var product in productOrder)
//            {
//                Console.WriteLine($"{product} - Rs{productPrices[product]}");
//            }

//            // SortedDictionary to display items sorted by price
//            SortedDictionary<double, List<string>> sortedByPrice = new SortedDictionary<double, List<string>>();
//            foreach (var kvp in productPrices)
//            {
//                if (!sortedByPrice.ContainsKey(kvp.Value))
//                    sortedByPrice[kvp.Value] = new List<string>();
//                sortedByPrice[kvp.Value].Add(kvp.Key);
//            }

//            Console.WriteLine("\nProducts sorted by price:");
//            foreach (var kvp in sortedByPrice)
//            {
//                foreach (var product in kvp.Value)
//                    Console.WriteLine($"{product} - Rs{kvp.Key}");
//            }
//        }
//    }
//}