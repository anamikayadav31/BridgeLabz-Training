using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class SumOfNaturalRecursion

    {
            public static void Main(string[] args)
            {
                //ask user to input number
                int n = int.Parse(Console.ReadLine());
                // call method
                int recursiveSum = SumUsingRecursion(n);
                // call formula method
                int formulaSum = SumUsingFormula(n);
                // Display both results
                Console.WriteLine("Sum using recursion is " + recursiveSum);
                Console.WriteLine("Sum using formula is " + formulaSum);

                // compare both results
                if (recursiveSum == formulaSum)
                {
                    Console.WriteLine("Both results are correct and equal");
                }
                else
                {
                    Console.WriteLine("Results are not equal");
                }
            }

            // create recursive method to find sum of n natural numbers
            public static int SumUsingRecursion(int n)
            {
                // Base condition
                if (n == 1)
                {
                    return 1;
                }

                // recursive call
                return n + SumUsingRecursion(n - 1);
            }

            // create method to find sum using formula 
            public static int SumUsingFormula(int n)
            {
                return n * (n + 1) / 2;
            }
        
    }
}

