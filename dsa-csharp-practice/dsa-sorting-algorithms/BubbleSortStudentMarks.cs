//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.sortingAlgorithms
//{
//    internal class BubbleSortStudentMarks
//    {
   

//        public static void Main(string[] args)
//        {
//            Console.Write("Enter number of students: ");
//            int n = int.Parse(Console.ReadLine());

//            int[] marks = new int[n];

//            // Taking marks input
//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter mark {i + 1}: ");
//                marks[i] = int.Parse(Console.ReadLine());
//            }

//            // Bubble Sort logic
//            for (int i = 0; i < n - 1; i++)
//            {
//                for (int j = 0; j < n - i - 1; j++)
//                {
//                    // Swap if next element is smaller
//                    if (marks[j] > marks[j + 1])
//                    {
//                        int temp = marks[j];
//                        marks[j] = marks[j + 1];
//                        marks[j + 1] = temp;
//                    }
//                }
//            }

//            Console.WriteLine("Sorted Student Marks:");
//            foreach (int m in marks)
//                Console.Write(m + " ");
//        }
//    }

//}
