using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    internal class FizzBuZZSec
    {
 
        public static void Main(string[] args)
        {
            //ask user to input number
            int number = int.Parse(Console.ReadLine());
            // Check if number is positive or not 
            if (number <= 0)
            {
                return;
            }
            // Create array
            string[] result = new string[number];
            // iterate Loop from 1 to number
            for (int i=1;i<=number;i++)
            {
                if (i%3==0 && i%5==0)
                {
                    result[i-1] ="FizzBuzz";
                }
                else if (i%3==0)
                {
                    result[i-1] ="Fizz";
                }
                else if (i%5==0)
                {
                    result[i-1] ="Buzz";
                }
                else
                {
                    result[i-1] =i.ToString();
                }
            }
            // Print result
            for (int i=0;i<result.Length;i++)
            {
                Console.WriteLine("Position " +(i+1) + " = " +result[i]);
            }
        }
    }

}

