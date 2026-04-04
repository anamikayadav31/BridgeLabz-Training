using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{
    internal class BankManagementScenerio2
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Factorial");
                Console.WriteLine("2. Prime Check");
                Console.WriteLine("3. GCD");
                Console.WriteLine("4. Fibonacci");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a number for factorial: ");
                        int nFact = int.Parse(Console.ReadLine());
                        Console.WriteLine("Factorial: " + MathUtility.Factorial(nFact));
                        break;

                    case 2:
                        Console.Write("Enter a number to check prime: ");
                        int nPrime = int.Parse(Console.ReadLine());
                        Console.WriteLine(nPrime + (MathUtility.IsPrime(nPrime) ? " is prime." : " is not prime."));
                        break;

                    case 3:
                        Console.Write("Enter first number for GCD: ");
                        int a = int.Parse(Console.ReadLine());
                        Console.Write("Enter second number for GCD: ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("GCD: " + MathUtility.GCD(a, b));
                        break;

                    case 4:
                        Console.Write("Enter n for Fibonacci: ");
                        int nFib = int.Parse(Console.ReadLine());
                        Console.WriteLine("Fibonacci(" + nFib + ") = " + MathUtility.Fibonacci(nFib));
                        break;

                    case 5:
                        Console.WriteLine("Exiting program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
    //create a class for mathemetical operations
    class MathUtility
    {//create a method to calculate factorial
        public static long Factorial(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
                return -1;
            }
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }
        //create a method to check number whether it is prime or not

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        //create a method to calculate gcd of two numbers

        public static int GCD(int a, int b)
        {
            if (a == 0) return Math.Abs(b);
            if (b == 0) return Math.Abs(a);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
        //create a method to calculate series
        public static long Fibonacci(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Fibonacci is not defined for negative numbers.");
                return -1;
            }
            if (n == 0) return 0;
            if (n == 1) return 1;
            long a = 0, b = 1, c = 0;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }


}
