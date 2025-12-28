using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class RecursionFactorial
    {
        

        public static void Main(string[] args)
        {
            // Take input from user
            int  n = int.Parse(Console.ReadLine());

            // call function
            long factorial = Factorial(n);

            // Display result
            Console.WriteLine("Factorial of " +  n + " is " + factorial);
        }

        // create  function to calculate factorial
        static long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }
    }

}

