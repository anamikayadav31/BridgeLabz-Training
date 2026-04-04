using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class CheckinNum
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int[] digits =  GetDigitsArray(number);

            Console.WriteLine("\nNumber of digits: " + digits.Length);
            Console.Write("Digits: ");
            Console.WriteLine(string.Join(" ", digits));

            Console.WriteLine("Sum of digits: " +  SumOfDigits(digits));
            Console.WriteLine("Sum of squares: " +  SumOfSquares(digits));
            Console.WriteLine("Harshad number: " +  IsHarshad(number, digits));

            Console.WriteLine("\nDigit Frequency:");
            Console.WriteLine("Digit\tCount");
            int[,] freq =  DigitFrequency(digits);
            for (int i = 0; i < 10; i++)
            {
                if (freq[i, 1] > 0)
                    Console.WriteLine(freq[i, 0] + "\t" + freq[i, 1]);
            }
        }


        // Method to count digits in a number
        public static int CountDigits(int number)
        {
            return number.ToString().Length;

        }

        // craete method to store digits of number in an array
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

        // create method to calculate sum of digits
        public static int SumOfDigits(int[] digits)
        {
            int sum = 0;
            foreach (int d in digits)
            {
                sum += d;
            }
            return sum;
        }

        // craete method to calculate sum of squares of digits
        public static int SumOfSquares(int[] digits)
        {
            int sum = 0;
            foreach (int d in digits)
            {
                sum += (int)Math.Pow(d, 2); // Square of digit
            }
            return sum;
        }

        // create method to check if number is a Harshad number
        public static bool IsHarshad(int number, int[] digits)
        {
            int sum = SumOfDigits(digits);
            return number % sum == 0; // True if divisible by sum of digits
        }

        // Method to find frequency of each digit
        public static int[,] DigitFrequency(int[] digits)
        {
            int[,] freq = new int[10, 2];




            for (int i = 0; i < 10; i++)
            {
                freq[i, 0] = i;
            }

            // Count frequency
            foreach (int d in digits)
            {
                freq[d, 1]++;

            }

            return freq;
        }
    }






}
