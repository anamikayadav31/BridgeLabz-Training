//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.sortingAlgorithms
//{
//    internal class CountingSortStudentAges
//    {
   

//       public static void Main(string[] args)
//        {
//            Console.Write("Enter number of students: ");
//            int n = int.Parse(Console.ReadLine());

//            int[] ages = new int[n];
//            int[] count = new int[19]; // index 0–18

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter age {i + 1}: ");
//                ages[i] = int.Parse(Console.ReadLine());
//                count[ages[i]]++; // count frequency
//            }

//            Console.WriteLine("Sorted Ages:");
//            for (int age = 10; age <= 18; age++)
//            {
//                while (count[age]-- > 0)
//                {
//                    Console.Write(age + " ");
//                }
//            }
//        }
//    }

//}
