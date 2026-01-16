//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.sortingAlgorithms
//{
//    internal class HeapSortSalary
//    {
   

//        static void Heapify(int[] arr, int n, int i)
//        {
//            int largest = i;
//            int left = 2 * i + 1;
//            int right = 2 * i + 2;

//            if (left < n && arr[left] > arr[largest])
//                largest = left;

//            if (right < n && arr[right] > arr[largest])
//                largest = right;

//            if (largest != i)
//            {
//                int temp = arr[i];
//                arr[i] = arr[largest];
//                arr[largest] = temp;

//                Heapify(arr, n, largest);
//            }
//        }

//        static void HeapSort(int[] arr)
//        {
//            int n = arr.Length;

//            // Build max heap
//            for (int i = n / 2 - 1; i >= 0; i--)
//                Heapify(arr, n, i);

//            // Extract elements
//            for (int i = n - 1; i >= 0; i--)
//            {
//                int temp = arr[0];
//                arr[0] = arr[i];
//                arr[i] = temp;

//                Heapify(arr, i, 0);
//            }
//        }

//        public static void Main(string[] args)
//        {
//            Console.Write("Enter number of applicants: ");
//            int n = int.Parse(Console.ReadLine());

//            int[] salary = new int[n];

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter expected salary {i + 1}: ");
//                salary[i] = int.Parse(Console.ReadLine());
//            }

//            HeapSort(salary);

//            Console.WriteLine("Sorted Salaries:");
//            foreach (int s in salary)
//                Console.Write(s + " ");
//        }
//    }

//}
