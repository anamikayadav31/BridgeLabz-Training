using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.sortingAlgorithm
{
    internal class QuickSorts
    {    
        public static void Main(string[] args)
        {
            // Ask how many products are there
            Console.Write("Enter number of products: ");
            int n = int.Parse(Console.ReadLine());

            int[] prices = new int[n];

            // Take product prices from user
            Console.WriteLine("Enter product prices:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Price of product " + (i + 1) + ": ");
                prices[i] = int.Parse(Console.ReadLine());
            }

            // Call quick sort
            QuickSort(prices, 0, n - 1);

            // Display sorted prices
            Console.WriteLine("\nProduct prices after sorting :");
            foreach (int p in prices)
            {
                Console.Write(p + " ");
            }
        }

        // Quick Sort method
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Get correct position of pivot
                int pivotIndex = Partition(arr, low, high);

                // Sort left side
                QuickSort(arr, low, pivotIndex - 1);

                // Sort right side
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        // This method places pivot at correct position
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];   // choosing last element as pivot
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                // If current price is smaller than pivot
                if (arr[j] < pivot)
                {
                    i++;

                    // Swap smaller element
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // Place pivot in correct place
            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;

            return i + 1;
        }
    }

}

