/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class SlidingWindowMaximum
    {
    

        static void FindMaxInWindows(int[] arr, int n, int k)
        {
            LinkedList<int> deque = new LinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                //remove indices out of this window
                if (deque.Count > 0 && deque.First.Value <= i - k)
                    deque.RemoveFirst();

                //remove smaller elements from back
                while (deque.Count > 0 && arr[deque.Last.Value] <= arr[i])
                    deque.RemoveLast();

                //add current index
                deque.AddLast(i);

                //print max once window is formed
                if (i >= k - 1)
                    Console.Write(arr[deque.First.Value] + " ");
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            Console.Write("Enter window size k: ");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine("\nSliding Window Maximum:");
            FindMaxInWindows(arr, n, k);
        }
    }

}
*/