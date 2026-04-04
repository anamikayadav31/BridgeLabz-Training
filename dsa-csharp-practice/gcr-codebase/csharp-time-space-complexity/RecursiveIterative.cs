using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.dataStructures.timeAndSpaceComplexity
{
    internal class RecursiveIterative
    {
        // Recursive Fibonacci
        static int FibonacciRecursive(int n)
        {
            if (n <= 1)
                return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        // Iterative Fibonacci
        static int FibonacciIterative(int n)
        {
            int a = 0, b = 1, sum = 0;

            for (int i = 2; i <= n; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
            }
            return b;
        }

       public static void Main(string[] args)
        {
            Console.Write("Enter Fibonacci number (N): ");
            int n = int.Parse(Console.ReadLine());

            Stopwatch sw = new Stopwatch();

            // Recursive
            sw.Start();
            int r = FibonacciRecursive(n);
            sw.Stop();
            Console.WriteLine("\nRecursive Result: " + r);
            Console.WriteLine("Time: " + sw.ElapsedMilliseconds + " ms");

            // Iterative
            sw.Restart();
            int i = FibonacciIterative(n);
            sw.Stop();
            Console.WriteLine("\nIterative Result: " + i);
            Console.WriteLine("Time: " + sw.ElapsedMilliseconds + " ms");

            Console.WriteLine("\nConclusion:");
            Console.WriteLine("Iterative approach is faster for large N.");
        }
    }
}

