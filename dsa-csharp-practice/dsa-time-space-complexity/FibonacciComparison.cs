using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.timeAndSpaceComplexity
{
    internal class FibonacciComparison
    {
       


        // Recursive Fibonacci
       

        public static int FibonacciRecursive(int n)
        {
            if (n <= 1)
                return n; // Base cases: Fib(0) = 0, Fib(1) = 1
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

     

        // Iterative Fibonacci (O(N))


        public static int FibonacciIterative(int n)
        {
            if (n <= 1)
                return n; // Handle base cases

            int a = 0, b = 1, sum = 0;
            for (int i = 2; i <= n; i++)
            {
                sum = a + b; // Next Fibonacci number
                a = b;       // Move forward
                b = sum;
            }
            return b; // Final Fibonacci number
        }

        static void Main()
        {
            // Ask user for the Fibonacci number to compute
            Console.WriteLine("Enter the value of N for Fibonacci:");
            int n = int.Parse(Console.ReadLine());


            // Recursive Approach


            Stopwatch sw = Stopwatch.StartNew(); // Start timer
            int fibRecursive = 0;

            // Warn user if N is too large
            if (n > 40)
            {
                Console.WriteLine("\nRecursive approach may take too long for large N (>40). Skipping...");
            }
            else
            {
                fibRecursive = FibonacciRecursive(n);
                sw.Stop();
                Console.WriteLine($"\nFibonacci (Recursive) = {fibRecursive}");
                Console.WriteLine($"Time taken (Recursive) = {sw.ElapsedMilliseconds} ms");
            }


            // Iterative Approach
           

            sw.Restart(); // Restart timer
            int fibIterative = FibonacciIterative(n);
            sw.Stop();

            Console.WriteLine($"\nFibonacci (Iterative) = {fibIterative}");
            Console.WriteLine($"Time taken (Iterative) = {sw.ElapsedMilliseconds} ms");
        }
    }

}
