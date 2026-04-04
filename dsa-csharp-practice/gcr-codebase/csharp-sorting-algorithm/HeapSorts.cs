using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.sortingAlgorithm
{
    internal class HeapSorts
    {
        public static void Main(string[] args)
        {
            // Ask how many job applicants are there
            Console.Write("Enter number of applicants: ");
            int n = int.Parse(Console.ReadLine());

            int[] salaries = new int[n];

            // Take salary demand from user
            Console.WriteLine("Enter expected salary of applicants:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Salary of applicant " + (i + 1) + ": ");
                salaries[i] = int.Parse(Console.ReadLine());
            }

            // Perform heap sort
            HeapSort(salaries);

            // Display sorted salaries
            Console.WriteLine("\nSalaries after sorting :");
            foreach (int s in salaries)
            {
                Console.Write(s + " ");
            }
        }

        // Main heap sort method
        static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Build Max Heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Remove elements one by one
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Fix the heap again
                Heapify(arr, i, 0);
            }
        }

        // This method fixes the heap property
        static void Heapify(int[] arr, int size, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // Check left child
            if (left < size && arr[left] > arr[largest])
                largest = left;

            // Check right child
            if (right < size && arr[right] > arr[largest])
                largest = right;

            // If root is not largest, swap and continue
            if (largest != root)
            {
                int temp = arr[root];
                arr[root] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, size, largest);
            }
        }
    }

}

