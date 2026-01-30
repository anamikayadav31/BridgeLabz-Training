using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.sortingAlgorithm
{
    internal class InsertionSort
    {
        public static void Main(string[] args)
        {
            // Ask how many employees are there
            Console.Write("Enter number of employees: ");
            int n = int.Parse(Console.ReadLine());

            int[] empIds = new int[n];

            // Take employee IDs from user
            Console.WriteLine("Enter Employee IDs:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Employee ID " + (i + 1) + ": ");
                empIds[i] = int.Parse(Console.ReadLine());
            }

            // Insertion Sort logic
            for (int i = 1; i < n; i++)
            {
                int key = empIds[i];   // current ID to insert
                int j = i - 1;

                // Move bigger IDs one step right
                while (j >= 0 && empIds[j] > key)
                {
                    empIds[j + 1] = empIds[j];
                    j--;
                }

                // Place ID in correct position
                empIds[j + 1] = key;
            }

            // Display sorted employee IDs
            Console.WriteLine("\nEmployee IDs after sorting :");
            foreach (int id in empIds)
            {
                Console.Write(id + " ");
            }
        }
    }

}

