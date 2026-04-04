using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    internal class OddEvenSave
    {
        public static void Main(string[] args)
        {
            // Get input from user
            int number = int.Parse(Console.ReadLine());
            // Check for natural number
            if (number <= 0)
            { 
                return;
            }
            // Create arrays
            int size = number / 2 + 1;
            int[] even = new int[size];
            int[] odd = new int[size];
            // Index variables
            int evenIndex = 0;
            int oddIndex = 0;
            // Store odd and even numbers
            for (int i = 1; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    even[evenIndex] = i;
                    evenIndex++;
                }
                else
                {
                    odd[oddIndex] = i;
                    oddIndex++;
                }
            }
            // Print odd numbers
            Console.WriteLine("Odd Numbers:");
            for (int i = 0; i < oddIndex; i++)
            {
                Console.Write(odd[i] + " ");
            }
            // Print even numbers
            Console.WriteLine("Even Numbers:");
            for (int i = 0; i < evenIndex; i++)
            {
                Console.Write(even[i] + " ");
            }
        }
    }

}

