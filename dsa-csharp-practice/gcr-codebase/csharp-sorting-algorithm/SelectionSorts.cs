using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.sortingAlgorithm
{
    internal class SelectionSorts
    {
        public static void Main(string[] args)
        {
            // Ask number of students
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            int[] scores = new int[n];

            // Take exam scores from user
            Console.WriteLine("Enter exam scores:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Score of student " + (i + 1) + ": ");
                scores[i] = int.Parse(Console.ReadLine());
            }

            // Selection Sort 
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;   

                // Find smallest score in remaining list
                for (int j = i + 1; j < n; j++)
                {
                    if (scores[j] < scores[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap only if needed
                if (minIndex != i)
                {
                    int temp = scores[i];
                    scores[i] = scores[minIndex];
                    scores[minIndex] = temp;
                }
            }

            // Print sorted scores
            Console.WriteLine("\nExam scores after sorting :");
            foreach (int s in scores)
            {
                Console.Write(s + " ");
            }
        }
    }
}

