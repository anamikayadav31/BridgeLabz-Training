using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class ExNumberCheck
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int[] factors =  GetFactors(number);

            Console.WriteLine("\nFactors: " + string.Join(" ", factors));
            Console.WriteLine("Greatest Factor: " + GreatestFactor(factors));
            Console.WriteLine("Sum of Factors: " + SumOfFactors(factors));
            Console.WriteLine("Product of Factors: " + ProductOfFactors(factors));
            Console.WriteLine("Product of Cube of Factors: " + ProductOfCubeFactors(factors));
            Console.WriteLine("Perfect Number: " + IsPerfect(number));
            Console.WriteLine("Abundant Number: " + IsAbundant(number));
            Console.WriteLine("Deficient Number: " + IsDeficient(number));
            Console.WriteLine("Strong Number: " + IsStrong(number));
        }

        //Find factors of a number
        public static int[] GetFactors(int number)
        {
            int count = 0;
            for (int i = 1; i <= number; i++)
                if (number % i == 0) count++;

            int[] factors = new int[count];
            int index = 0;
            for (int i = 1; i <= number; i++)
                if (number % i == 0) factors[index++] = i;

            return factors;
        }

        // Greatest factor
        public static int GreatestFactor(int[] factors)
        {
            return factors[factors.Length - 1]; // Last factor is the greatest
        }

        // Sum of factors
        public static int SumOfFactors(int[] factors)
        {
            int sum = 0;
            foreach (int f in factors) sum += f;
            return sum;
        }

        // Product of factors
        public static long ProductOfFactors(int[] factors)
        {
            long product = 1;
            foreach (int f in factors) product *= f;
            return product;
        }

        //Product of cube of factors
        public static long ProductOfCubeFactors(int[] factors)
        {
            long product = 1;
            foreach (int f in factors) product *= (long)Math.Pow(f, 3);
            return product;
        }

        //. Check perfect number
        public static bool IsPerfect(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
                if (number % i == 0) sum += i;
            return sum == number;
        }

        //Check abundant number
        public static bool IsAbundant(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
                if (number % i == 0) sum += i;
            return sum > number;
        }

        //Check deficient number
        public static bool IsDeficient(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
                if (number % i == 0) sum += i;
            return sum < number;
        }

        // Check strong number (sum of factorial of digits equals number)
        public static bool IsStrong(int number)
        {
            int sum = 0, temp = number;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += Factorial(digit);
                temp /= 10;
            }
            return sum == number;
        }

        // factorial of a number
        private static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++) fact *= i;
            return fact;
        }
    }

}