//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.sortingAlgorithms
//{
//    internal class SelectionSortExamScores
//    {
   

//        public static void Main(string[] args)
//        {
//            Console.Write("Enter number of students: ");
//            int n = int.Parse(Console.ReadLine());

//            int[] scores = new int[n];

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter score {i + 1}: ");
//                scores[i] = int.Parse(Console.ReadLine());
//            }

//            // Selection Sort logic
//            for (int i = 0; i < n - 1; i++)
//            {
//                int minIndex = i;

//                for (int j = i + 1; j < n; j++)
//                {
//                    if (scores[j] < scores[minIndex])
//                        minIndex = j;
//                }

//                int temp = scores[minIndex];
//                scores[minIndex] = scores[i];
//                scores[i] = temp;
//            }

//            Console.WriteLine("Sorted Exam Scores:");
//            foreach (int s in scores)
//                Console.Write(s + " ");
//        }
//    }

//}
