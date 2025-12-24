using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    class CheckAge
    {
        public static void Main(string[] args)
        {//create an array of length 10 
            int[] arr = new int[10];
            for(int i = 0; i < arr.Length; i++)
            {//take input from user
                arr[i] = int.Parse(Console.ReadLine());
            }//iterate loop 
            for(int i = 0; i < arr.Length; i++)
            {//check age is greater than equals to 18 or not
                if (arr[i] >= 18)
                {
                    Console.WriteLine("User can vote");
                }
                else
                {
                    Console.WriteLine("User cannot vote");
                }
            }
        }

    
    }
}
