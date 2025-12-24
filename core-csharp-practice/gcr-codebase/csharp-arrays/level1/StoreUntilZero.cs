using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    class StoreUntilZero
    {
        public static void Main(string[] args)
        {
            // Create an array of size 10
            double[] numbers = new double[10];
            double total = 0.0;
            int index = 0;

            // Infinite loop
            while (true)
            {
                double input = double.Parse(Console.ReadLine());

                // Break if input is 0 or negative
                if (input <= 0)
                {
                    break;
                }
                // Break if array size reaches 10
                if (index == 10)
                {
                    break;
                }
                // Store value in array
                numbers[index] = input;
                index++;
            }
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(numbers[i]);
                total += numbers[i];
            }

            // Display total
            Console.WriteLine("Total sum = " + total);
        }
    }
}

