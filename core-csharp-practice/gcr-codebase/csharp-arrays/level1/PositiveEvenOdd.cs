using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    class PositiveEvenOdd
    {
        public static void Main(string[] args)
        {//create an array of length 5 
            int[] arr = new int[5];
            for (int i = 0; i < arr.Length; i++)
            {//take input from user
                arr[i] = int.Parse(Console.ReadLine());
            }//iterate loop 
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    if (arr[i] % 2 == 0)
                    {
                        Console.WriteLine("The number is positive and even");
                    }
                    else
                    {
                        Console.WriteLine("The number is positive and odd");
                    }
                }

                else if (arr[i] < 0)
                {
                    Console.WriteLine("The number is negative");
                }
                else
                {
                    Console.WriteLine("The number is zero");
                }
            }
            if (arr[0] > arr[arr.Length - 1])
            {
                Console.WriteLine("first element is greater than last element");
            }
            else if (arr[0] < arr[arr.Length-1])
            {
                Console.WriteLine("first element is less than last element");
            }
            else
            {
                Console.WriteLine("first element is equals to last element");
            }
        }

    }
    
}
