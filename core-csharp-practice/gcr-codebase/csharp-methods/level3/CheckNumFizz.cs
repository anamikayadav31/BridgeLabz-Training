using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class CheckNumFizz
    {


        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPrime Number: " +  IsPrime(number));
            Console.WriteLine("Neon Number: " +  IsNeon(number));
            Console.WriteLine("Spy Number: " +  IsSpy(number));
            Console.WriteLine("Automorphic Number: " +    IsAutomorphic(number));
            Console.WriteLine("Buzz Number: " +  IsBuzz(number));
        }
    
        // Check prime number
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        //Check neon number
        public static bool IsNeon(int number)
        {
            int square = number * number;
            int sum = 0;
            while (square > 0)
            {
                sum += square % 10;
                square /= 10;
            }
            return sum == number;
        }

        // Check spy number
        public static bool IsSpy(int number)
        {
            int sum = 0, product = 1, temp = number;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += digit;
                product *= digit;
                temp /= 10;
            }
            return sum == product;
        }

        // Check automorphic number
        public static bool IsAutomorphic(int number)
        {
            int square = number * number;
            string numStr = number.ToString();
            string squareStr = square.ToString();
            return squareStr.EndsWith(numStr);
        }

        // Check buzz number
        public static bool IsBuzz(int number)
        {
            return number % 7 == 0 || number % 10 == 7;
        }
    }

   




}
