using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class NumberCheckMethod
    {


        public static void Main(string[] args)
        {
            int[] numbers = new int[5];

            //ask user to input
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Enter number " + (i + 1) + ":");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // Loop 
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsPositive(numbers[i]))
                {
                    Console.Write(numbers[i] + " is positive");

                    if (IsEven(numbers[i]))
                    {
                        Console.WriteLine(" and even");
                    }
                    else
                    {
                        Console.WriteLine(" and odd");
                    }
                }
                else
                {
                    Console.WriteLine(numbers[i] + " is negative");
                }
            }

            // compare first and last element
            int comparison = Compare(numbers[0], numbers[4]);

            if (comparison == 1)
            {
                Console.WriteLine("The first number is greater than the last number.");
            }
            else if (comparison == 0)
            {
                Console.WriteLine("The first number is equal to the last number.");
            }
            else
            {
                Console.WriteLine("The first number is less than the last number.");
            }
        }

        // create method to check if number is positive
        public static bool IsPositive(int number)
        {
            return number >= 0;
        }

        // create method to check if number is even
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // create method to compare two numbers
        public static int Compare(int number1, int number2)
        {
            if (number1 > number2)
            {
                return 1;
            }
            else if (number1 == number2)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    

}

