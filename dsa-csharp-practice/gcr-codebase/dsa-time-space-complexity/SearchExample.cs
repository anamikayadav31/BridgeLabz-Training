using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.timeAndSpaceComplexity
{



    class SearchExample
    {

        //linear search
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == target) return i;
            return -1;
        }
        //binary search
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == target) return mid;
                else if (arr[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }
        //main class
        static void Main()
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());
            int[] data = new int[n];

            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++) data[i] = int.Parse(Console.ReadLine());

            Console.Write("Enter target to search: ");
            int target = int.Parse(Console.ReadLine());

            Stopwatch sw = new Stopwatch();

            // Linear Search
            sw.Start();
            int indexLinear = LinearSearch(data, target);
            sw.Stop();
            long timeLinear = sw.ElapsedMilliseconds;

            // Binary Search
            Array.Sort(data);
            sw.Restart();
            int indexBinary = BinarySearch(data, target);
            sw.Stop();
            long timeBinary = sw.ElapsedMilliseconds;

            Console.WriteLine($"\nLinear Search: Index = {indexLinear}, Time = {timeLinear} ms");
            Console.WriteLine($"Binary Search: Index = {indexBinary}, Time = {timeBinary} ms");

            // Show which is faster
            if (timeLinear < timeBinary) Console.WriteLine("Linear Search is faster.");
            else if (timeBinary < timeLinear) Console.WriteLine("Binary Search is faster.");
            else Console.WriteLine("Both searches took the same time.");
        }
    }
}