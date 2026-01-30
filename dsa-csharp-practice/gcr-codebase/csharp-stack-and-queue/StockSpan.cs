using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    internal class StockSpan
    {
            public static void CalculateSpan(int[] prices, int n)
            {
                int[] span = new int[n];

                // Stack stores indices of days
                Stack<int> stack = new Stack<int>();

                // First day span is always 1
                span[0] = 1;
                stack.Push(0);

                // Calculate span for remaining days
                for (int i = 1; i < n; i++)
                {
                    // Remove indices with smaller or equal price
                    while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
                    {
                        stack.Pop();
                    }

                    // If stack is empty, span is i + 1
                    if (stack.Count == 0)
                    {
                        span[i] = i + 1;
                    }
                    else
                    {
                        span[i] = i - stack.Peek();
                    }

                    // Push current day index
                    stack.Push(i);
                }

                // Print result
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

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter price for day " + (i + 1) + ": ");
                    prices[i] = int.Parse(Console.ReadLine());
                }

                CalculateSpan(prices, n);
            }
        }
    }


