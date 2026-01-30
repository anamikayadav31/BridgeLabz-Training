using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.sortingAlgorithm
{
    internal class BubbleSort
    {
        public static void Main(string[] args)
        {
            // Ask how many students are there
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            int[] marks = new int[n];

            // Take marks from user
            Console.WriteLine("Enter student marks:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Mark " + (i + 1) + ": ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            // Bubble Sort logic
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // Swap if left mark is bigger
                    if (marks[j] > marks[j + 1])
                    {
                        int temp = marks[j];
                        marks[j] = marks[j + 1];
                        marks[j + 1] = temp;
                    }
                }
            }

            // Display sorted marks
            Console.WriteLine("\nMarks after sorting :");
            foreach (int m in marks)
            {
                Console.Write(m + " ");
            }
        }
    }

}

