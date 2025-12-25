using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class SumOfNaturalMethod
    {
        public static void Main(string[] args)
        {
            //ask user to input a number
            int n = int.Parse(Console.ReadLine());
            //call method
            Console.WriteLine(SumOfNaturalNumbers(n));

        }//create a method to sum of natural numbers
        public static int SumOfNaturalNumbers(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i; // Add each number to sum
            }
            return sum;
        }


    }
}
