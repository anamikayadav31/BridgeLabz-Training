using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.timeAndSpaceComplexity
{
    internal class SortingExample
    {
       

      

        // Bubble Sort Implementation
   

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            // Traverse through all array elements
            for (int i = 0; i < n - 1; i++)
            {
                // Last i elements are already in place
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Swap if the element found is greater than next element
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

      

        // Merge Sort Implementation
     

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                // Sort first and second halves recursively
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                // Merge the sorted halves
                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1; // Size of left subarray
            int n2 = right - mid;    // Size of right subarray

            // Create temporary arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            // Copy data to temp arrays
            for (int i = 0; i < n1; i++) L[i] = arr[left + i];
            for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, k = left;

            // Merge temp arrays back into arr[left..right]
            while (iIndex < n1 && jIndex < n2)
            {
                if (L[iIndex] <= R[jIndex])
                {
                    arr[k] = L[iIndex];
                    iIndex++;
                }
                else
                {
                    arr[k] = R[jIndex];
                    jIndex++;
                }
                k++;
            }

            // Copy remaining elements of L[], if any
            while (iIndex < n1)
            {
                arr[k] = L[iIndex];
                iIndex++;
                k++;
            }

            // Copy remaining elements of R[], if any
            while (jIndex < n2)
            {
                arr[k] = R[jIndex];
                jIndex++;
                k++;
            }
        }


        // Quick Sort Implementation
    

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition the array
                int pi = Partition(arr, low, high);

                // Recursively sort elements before and after partition
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // Choose the last element as pivot
            int i = low - 1;       // Index of smaller element

            for (int j = low; j < high; j++)
            {
                // If current element is smaller than pivot, swap it
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // Swap pivot element to its correct position
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1; // Return partition index
        }


        // Main Method
  

        static void Main()
        {
            // Take input from user for array size
            Console.WriteLine("Enter the number of elements:");
            int n = int.Parse(Console.ReadLine());
            int[] data = new int[n];

            // Take array elements input from user
            Console.WriteLine($"Enter {n} integers:");
            for (int i = 0; i < n; i++)
            {
                data[i] = int.Parse(Console.ReadLine());
            }

       

            // Bubble Sort
        

          

            int[] bubble = new int[data.Length]; // create a new array of same length
            for (int i = 0; i < data.Length; i++)
            {
                bubble[i] = data[i]; // copy each element
            }
            Stopwatch sw = Stopwatch.StartNew(); // Start timer
            BubbleSort(bubble);
            sw.Stop(); // Stop timer
            Console.WriteLine("\nBubble Sort Result:");
            Console.WriteLine(string.Join(", ", bubble)); // Print sorted array
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");



            // Merge Sort

            int[] merge = new int[data.Length]; // create a new array of same length
            for (int i = 0; i < data.Length; i++)
            {
                merge[i] = data[i]; // copy each element
            }

            sw.Restart(); // Restart timer
            MergeSort(merge, 0, merge.Length - 1);
            sw.Stop();
            Console.WriteLine("\nMerge Sort Result:");
            Console.WriteLine(string.Join(", ", merge));
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

           

            // Quick Sort
           
            int[] quick = new int[data.Length]; // create a new array of same length
            for (int i = 0; i < data.Length; i++)
            {
                quick[i] = data[i]; // copy each element
            }
            sw.Restart();
            QuickSort(quick, 0, quick.Length - 1);
            sw.Stop();
            Console.WriteLine("\nQuick Sort Result:");
            Console.WriteLine(string.Join(", ", quick));
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");
        }
    }




}



