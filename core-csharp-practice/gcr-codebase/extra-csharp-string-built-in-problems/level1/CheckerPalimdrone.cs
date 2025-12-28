using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class CheckerPalimdrone
    {
        public static void Main(string[] args)
        {//ask user to input a string
            string text = Console.ReadLine();
            //call method 
            bool result = IsPalindrome(text);

            if (result)
                Console.WriteLine("The string is a palindrome.");
            else
                Console.WriteLine("The string is not a palindrome.");
        }

        // create a function to check palindrome
        public static bool IsPalindrome(string input)
        {
            string cleaned = input.Replace(" ", "").ToLower();
            char[] chars = cleaned.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);

            return cleaned == reversed;
        }
    }
}