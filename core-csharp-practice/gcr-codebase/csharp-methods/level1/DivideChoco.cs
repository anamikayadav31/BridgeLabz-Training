using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class DivideChoco
    {
 

        public static void Main(string[] args)
        {
            //ask user to input no of chocolates
            int numberOfChocolates = int.Parse(Console.ReadLine());
            //ask user to input no of children
            int numberOfChildren = int.Parse(Console.ReadLine());

            //Call method
            int[] result = FindRemainderAndQuotient(numberOfChocolates, numberOfChildren);

            //Print results
            Console.WriteLine("Each child gets: " + result[0] + " chocolates");
            Console.WriteLine("Remaining chocolates: " + result[1]);
        }

        // create method to find quotient and remainder
        public static int[] FindRemainderAndQuotient(int number, int divisor)
        {
            int[] res = new int[2];
            // chocolates each child gets
            int d = number / divisor;
            res[0] = d;
            // remaining chocolates
            int rem = number % divisor;
            res[1] = rem;
            return res;
        }
    }

}
}
