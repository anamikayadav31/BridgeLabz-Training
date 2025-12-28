using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class Febonacci
    {

        public static void Main(string[] args)
        {
            // Ask user to input a number
           
            int n= int.Parse(Console.ReadLine());

            // Call function
            PrintFibonacci(n);
        }

        //  create a function to calculate  Fibonacci 
        static void PrintFibonacci(int n)
        {
            // initialize first two numbers
            int a = 0;
            int b = 1;

            // Loop to generate sequence
            for (int i = 1; i <= n; i++)
            {
           
                Console.Write(a + " ");
                int next = a + b;

                // Update values
                a = b;
                b = next;
            }
        }
    }

}

