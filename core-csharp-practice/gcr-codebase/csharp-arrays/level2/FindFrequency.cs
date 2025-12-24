using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class FindFrequency
    {


        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            int temp = n;

            // Frequency array for digits 0-9
            int[] frequency = new int[10];

            // Count frequency of each digit
            if (temp == 0) frequency[0] = 1; // handle 0 input
            while (temp != 0)
            {
                int rem = temp % 10;
                frequency[rem]++;
                temp /= 10;
            }

            // Display frequency
            for (int i = 0; i < 10; i++)
            {
                if (frequency[i] > 0)
                {
                    Console.WriteLine($"Digit {i}: {frequency[i]} times");
                }
            }
        }
    }
}