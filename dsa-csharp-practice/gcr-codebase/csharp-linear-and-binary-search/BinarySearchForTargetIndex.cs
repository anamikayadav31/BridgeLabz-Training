using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class BinarySearchForTargetIndex
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter target value to search: ");
            int target = int.Parse(Console.ReadLine());

            // Sort array (Bubble Sort)
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            int index = BinarySearch(arr, n, target);

            if (index != -1)
            {
                Console.WriteLine("Target found at index: " + index);
            }
            else
            {
                Console.WriteLine("Target not found");
            }
        }

        // Binary Search method
        static int BinarySearch(int[] arr, int n, int target)
        {
            int left = 0;
            int right = n - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
