using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class SmallestAndLargest
    {
        public static void Main(string[] args)
        {//ask user to input three numbers 
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            //call method
            int[] result = FindSmallestAndLargest(number1, number2, number3);

            // print results
            Console.WriteLine("Smallest number is  " + result[0]);
            Console.WriteLine("Largest number is  " + result[1]);
        }
        // create method to find the smallest and largest of three numbers
        public static int[] FindSmallestAndLargest(int number1, int number2, int number3)
        {
            int smallest = number1;
            int largest = number1;
            // Compare with second number
            if (number2 < smallest)
            {
                smallest = number2;
            }
            if (number2 > largest)
            {
                largest = number2;
            }
            // Compare with third number
            if (number3 < smallest)
            {
                smallest = number3;
            }
            if (number3 > largest)
            {
                largest = number3;
            }
            // Return smallest and largest as an array
            return new int[] { smallest, largest };
        }
    }
}
           

           

           
           



        

