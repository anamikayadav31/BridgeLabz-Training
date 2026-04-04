using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class ReverseTheNumber
    {
        public static void Main(string[] args)
        {//ask user to input a number
            int num=int.Parse(Console.ReadLine());
            //store numbrer into a temporary variable
            int temp = num;
   //initialise count and idx as 0
            int count = 0;
            int idx = 0;
            //compute no. of digits
            while (temp != 0)
            {
                temp = temp / 10;
                count++;
                
            }//print count
            Console.WriteLine("The Count of digits is "+count);
            //creates an array
            int[] arr = new int[count];
            //reverse the number
            while (num != 0)
            {
                int rem=num % 10;
                arr[idx++] = rem;
                num = num / 10;
            }
            for(int i = 0; i < arr.Length; i++)
            {
                
                Console.Write(arr[i]);
            }
        }
    }
}
