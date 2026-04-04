using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class PalimdroneStr
    {
 
        public static void Main(string[] args)
        {


            string  s = Console.ReadLine();

            // Convert to lowercase
            string  x =  s.ToLower().Replace(" ", "");

            bool isPalindrome = true;
            int length =  x.Length;

            // Compare characters from start and end
            for (int i = 0; i < length / 2; i++)
            {
                if ( x[i] != x[length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine("The string is a palindrome.");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome.");
            }
        }
    }

}
