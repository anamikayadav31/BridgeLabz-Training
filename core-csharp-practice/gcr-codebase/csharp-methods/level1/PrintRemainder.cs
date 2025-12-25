using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class PrintRemainder
    {
        public static void Main(string[] args)
        {//ask user to input a number 
            int number=int.Parse(Console.ReadLine());
            //ask user to input a divisor
            int divisor =int.Parse(Console.ReadLine());
            // Call method and store result
            int[] result = FindRemainderAndQuotient(number, divisor);

            // Print quotient and remainder
            Console.WriteLine("Quotient: " + result[0]);
            Console.WriteLine("Remainder: " + result[1]);
        }
        //create a method to return quotient and remainder
        public static int[] FindRemainderAndQuotient(int number, int divisor)
        {
            int[] res = new int[2];
            //calculate quotient
            int d = number / divisor;
            //calculate remainder
            int r=number % divisor;
            res[0] = d;
            res[1] = r;
            return res;
        }

    }
}
