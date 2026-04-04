using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.dataStructures.timeAndSpaceComplexity
{
    internal class SortingLargeData
    {
        // Bubble Sort
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // Merge Sort
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int i1 = 0, j1 = 0, k = left;

            while (i1 < n1 && j1 < n2)
            {
                if (L[i1] <= R[j1])
                    arr[k++] = L[i1++];
                else
                    arr[k++] = R[j1++];
            }

            while (i1 < n1)
                arr[k++] = L[i1++];

            while (j1 < n2)
                arr[k++] = R[j1++];
        }

        // Quick Sort
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int p = Partition(arr, low, high);
                QuickSort(arr, low, p - 1);
                QuickSort(arr, p + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int t = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = t;

            return i + 1;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Random r = new Random();

            // Generate random data
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(1, 10000);
            }

            Stopwatch sw = new Stopwatch();

            // Bubble Sort
            int[] bubbleArr = (int[])arr.Clone();
            sw.Start();
            BubbleSort(bubbleArr);
            sw.Stop();
            Console.WriteLine("\nBubble Sort Time: " + sw.ElapsedMilliseconds + " ms");

            // Merge Sort
            int[] mergeArr = (int[])arr.Clone();
            sw.Restart();
            MergeSort(mergeArr, 0, mergeArr.Length - 1);
            sw.Stop();
            Console.WriteLine("Merge Sort Time: " + sw.ElapsedMilliseconds + " ms");

            // Quick Sort
            int[] quickArr = (int[])arr.Clone();
            sw.Restart();
            QuickSort(quickArr, 0, quickArr.Length - 1);
            sw.Stop();
            Console.WriteLine("Quick Sort Time: " + sw.ElapsedMilliseconds + " ms");

            Console.WriteLine("\nConclusion:");
            Console.WriteLine("Bubble Sort is slow for large data.");
            Console.WriteLine("Merge Sort and Quick Sort are efficient.");
        }
    }

}

