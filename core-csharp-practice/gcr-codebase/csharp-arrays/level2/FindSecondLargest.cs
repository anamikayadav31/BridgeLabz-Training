using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class FindSecondLargest
    {
        public static void Main(string[] args)
        {
            // initial size of array
            int maxDigit = 10;
            int[] digits = new int[maxDigit];
            int index = 0;
            while (true)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    break;
                }
                // if index reaches maxDigit, increase size by 10
                if (index == maxDigit)
                {
                    maxDigit += 10;
                 
                    // create temp array with increased size
                    int[] temp = new int[maxDigit];
                    // copy old elements
                    for (int i = 0; i < digits.Length; i++)
                    {
                        temp[i] = digits[i];
                    }
                    digits = temp;
                }

                // store number
                digits[index] = num;
                index++;
            }
            // initialize max and second max
            int max = int.MinValue;
            int secMax = int.MinValue;
            // find largest and second largest
            for (int i = 0; i < index; i++)
            {
                if (digits[i] > max)
                {
                    secMax = max;
                    max = digits[i];
                }
                else if (digits[i] > secMax && digits[i] < max)
                {
                    secMax = digits[i];
                }
            }
            // print result
            Console.WriteLine("Largest Number: " + max);
            Console.WriteLine("Second Largest Number: " + secMax);
        }
    }

}

