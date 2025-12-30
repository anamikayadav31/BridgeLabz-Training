using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.leetcode
{
    internal class PalindromeNumberProblem9
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int temp = n;
            while (n != 0)
            {
                int rem = n % 10;
                sum = sum * 10 + rem;
                n = n / 10;
            }

            if (temp == sum)
            {
                Console.WriteLine("It is a Palindrome Number");
            }
            else
            {
                Console.WriteLine("It is not a Palindrome Number");
            }
        }


    }
}
