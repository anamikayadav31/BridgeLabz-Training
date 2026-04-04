using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class CheckPrimeee
    {
      
        public static void Main(string[] args)
        {
            //ask user to input a number
            int  n = int.Parse(Console.ReadLine());
            
            bool isPrime = IsPrime(n);
            //call method and check
            if (isPrime)
                Console.WriteLine("The number is prime");
            else
                Console.WriteLine("The number is not prime");
        }
        //create a method to check a number is prime or not
        public static bool IsPrime(int  n)
        {
            if ( n <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt( n); i++)
            {
                if ( n % i == 0)
                    return false;
            }

            return true;
        }
    }

}