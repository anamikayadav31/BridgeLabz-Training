using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.sortingAlgorithm
{
    internal class MergeSorts
    {
        public static void Main(string[] args)
        {
            // Ask how many books are there
            Console.Write("Enter number of books: ");
            int n = int.Parse(Console.ReadLine());

            int[] prices = new int[n];

            // Take book prices from user
            Console.WriteLine("Enter book prices:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Price of book " + (i + 1) + ": ");
                prices[i] = int.Parse(Console.ReadLine());
            }

            // Call merge sort
            MergeSort(prices, 0, n - 1);

            // Print sorted prices
            Console.WriteLine("\nBook prices after sorting :");
            foreach (int p in prices)
            {
                Console.Write(p + " ");
            }
        }

        // This method divides the array
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                // Sort left half
                MergeSort(arr, left, mid);

                // Sort right half
                MergeSort(arr, mid + 1, right);

                // Merge both halves
                Merge(arr, left, mid, right);
            }
        }

        // This method merges two sorted parts
        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            // Copy data to temp arrays
            for (int i = 0; i < n1; i++)
                leftArr[i] = arr[left + i];

            for (int j = 0; j < n2; j++)
                rightArr[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, k = left;

            // Compare and merge
            while (iIndex < n1 && jIndex < n2)
            {
                if (leftArr[iIndex] <= rightArr[jIndex])
                {
                    arr[k] = leftArr[iIndex];
                    iIndex++;
                }
                else
                {
                    arr[k] = rightArr[jIndex];
                    jIndex++;
                }
                k++;
            }

            // Copy remaining elements
            while (iIndex < n1)
            {
                arr[k] = leftArr[iIndex];
                iIndex++;
                k++;
            }

            while (jIndex < n2)
            {
                arr[k] = rightArr[jIndex];
                jIndex++;
                k++;
            }
        }
    }
}

