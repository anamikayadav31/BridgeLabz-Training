//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.sortingAlgorithms
//{
//    internal class MergeSortBookPrices
//    {
   

//        static void Merge(int[] arr, int left, int mid, int right)
//        {
//            int n1 = mid - left + 1;
//            int n2 = right - mid;

//            int[] L = new int[n1];
//            int[] R = new int[n2];

//            // Copy data to temp arrays
//            for (int i = 0; i < n1; i++) L[i] = arr[left + i];
//            for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

//            int iIndex = 0, jIndex = 0, k = left;

//            // Merge arrays
//            while (iIndex < n1 && jIndex < n2)
//            {
//                if (L[iIndex] <= R[jIndex])
//                    arr[k++] = L[iIndex++];
//                else
//                    arr[k++] = R[jIndex++];
//            }

//            // Copy remaining elements
//            while (iIndex < n1) arr[k++] = L[iIndex++];
//            while (jIndex < n2) arr[k++] = R[jIndex++];
//        }

//        static void MergeSort(int[] arr, int left, int right)
//        {
//            if (left < right)
//            {
//                int mid = (left + right) / 2;
//                MergeSort(arr, left, mid);
//                MergeSort(arr, mid + 1, right);
//                Merge(arr, left, mid, right);
//            }
//        }

//        public static void Main(string[] args)
//        {
//            Console.Write("Enter number of books: ");
//            int n = int.Parse(Console.ReadLine());

//            int[] prices = new int[n];

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter price {i + 1}: ");
//                prices[i] = int.Parse(Console.ReadLine());
//            }

//            MergeSort(prices, 0, n - 1);

//            Console.WriteLine("Sorted Book Prices:");
//            foreach (int p in prices)
//                Console.Write(p + " ");
//        }
//    }

//}
