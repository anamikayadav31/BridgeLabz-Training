//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.sortingAlgorithms
//{
//    internal class InsertionSortEmployeeIDs
//    {
   
//        public static void Main(string[] args)
//        {
//            Console.Write("Enter number of employees: ");
//            int n = int.Parse(Console.ReadLine());

//            int[] ids = new int[n];

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter Employee ID {i + 1}: ");
//                ids[i] = int.Parse(Console.ReadLine());
//            }

//            // Insertion Sort logic
//            for (int i = 1; i < n; i++)
//            {
//                int key = ids[i];
//                int j = i - 1;

//                // Shift elements to the right
//                while (j >= 0 && ids[j] > key)
//                {
//                    ids[j + 1] = ids[j];
//                    j--;
//                }
//                ids[j + 1] = key;
//            }

//            Console.WriteLine("Sorted Employee IDs:");
//            foreach (int id in ids)
//                Console.Write(id + " ");
//        }
//    }

//}
