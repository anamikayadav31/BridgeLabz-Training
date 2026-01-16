//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.sortingAlgorithms
//{
//    internal class QuickSortProductPrices
//    {
   

//        static int Partition(int[] arr, int low, int high)
//        {
//            int pivot = arr[high];
//            int i = low - 1;

//            for (int j = low; j < high; j++)
//            {
//                if (arr[j] < pivot)
//                {
//                    i++;
//                    int temp = arr[i];
//                    arr[i] = arr[j];
//                    arr[j] = temp;
//                }
//            }

//            int t = arr[i + 1];
//            arr[i + 1] = arr[high];
//            arr[high] = t;

//            return i + 1;
//        }

//        static void QuickSort(int[] arr, int low, int high)
//        {
//            if (low < high)
//            {
//                int pi = Partition(arr, low, high);
//                QuickSort(arr, low, pi - 1);
//                QuickSort(arr, pi + 1, high);
//            }
//        }

//        public static void Main(string[] args)
//        {
//            Console.Write("Enter number of products: ");
//            int n = int.Parse(Console.ReadLine());

//            int[] prices = new int[n];

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter price {i + 1}: ");
//                prices[i] = int.Parse(Console.ReadLine());
//            }

//            QuickSort(prices, 0, n - 1);

//            Console.WriteLine("Sorted Product Prices:");
//            foreach (int p in prices)
//                Console.Write(p + " ");
//        }
//    }

//}
