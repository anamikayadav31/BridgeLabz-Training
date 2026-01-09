using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class StockSpanProblem
    {
   

        static void CalculateSpan(int[] prices, int n)
        {
            int[] span = new int[n];
            Stack<int> stack = new Stack<int>(); // stores indices

            // First day span is always 1
            span[0] = 1;
            stack.Push(0);

            for (int i = 1; i < n; i++)
            {
                // Pop indices while current price is higher
                while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
                {
                    stack.Pop();
                }

                // If stack empty, span = i + 1
                span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());

                // Push current index
                stack.Push(i);
            }

            Console.WriteLine("\nStock Spans:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(span[i] + " ");
            }
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter number of days: ");
            int n = int.Parse(Console.ReadLine());

            int[] prices = new int[n];

            Console.WriteLine("Enter stock prices:");
            for (int i = 0; i < n; i++)
            {
                prices[i] = int.Parse(Console.ReadLine());
            }

            CalculateSpan(prices, n);
        }
    }

}
