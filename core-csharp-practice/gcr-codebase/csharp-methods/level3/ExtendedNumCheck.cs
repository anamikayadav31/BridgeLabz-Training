using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class ExtendedNumCheck
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int[] digits = GetDigitsArray(number);

            // Display digits
            Console.WriteLine("Digits: " + string.Join(" ", digits));

            // Reverse digits
            int[] reversed =  ReverseArray(digits);
            Console.WriteLine("Reversed: " + string.Join(" ", reversed));

            // Palindrome check
            Console.WriteLine("Palindrome: " + IsPalindrome(digits));

            // Duck number check
            Console.WriteLine("Duck Number: " + IsDuckNumber(digits));
        }

        //Count digits
        public static int CountDigits(int number)
        {
            return number.ToString().Length;
        }

        // Store digits in array
        public static int[] GetDigitsArray(int number)
        {
            int count = CountDigits(number);
            int[] digits = new int[count];
            int temp = number;
            for (int i = count - 1; i >= 0; i--)
            {
                digits[i] = temp % 10;
                temp /= 10;
            }
            return digits;
        }

        //Reverse digits array
        public static int[] ReverseArray(int[] digits)
        {
            int[] rev = new int[digits.Length];
            for (int i = 0; i < digits.Length; i++)
            {
                rev[i] = digits[digits.Length - 1 - i];
            }
            return rev;
        }

        // Compare two arrays
        public static bool AreArraysEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }

        // Check palindrome using digits
        public static bool IsPalindrome(int[] digits)
        {
            int[] reversed = ReverseArray(digits);
            return AreArraysEqual(digits, reversed);
        }

        //Check duck number (contains at least one non-zero digit)
        public static bool IsDuckNumber(int[] digits)
        {
            foreach (int d in digits)
            {
                if (d != 0) return true;
            }
            return false;
        }
    }

}
    

       

  
