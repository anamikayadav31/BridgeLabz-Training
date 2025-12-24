using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class LargestAndSecondLargest
    {
        public static void Main(string[] args)
        {//ask user to input arraysize
            int n = int.Parse(Console.ReadLine());
            //create array
            int[] arr = new int[n];
            //ask user to input elements in array
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            //initialise variables as 0
            int max = int.MinValue;
            int secMax = int.MinValue;
            //find largest
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > max)
                {
                    secMax = max;
                    max = arr[i];
                }

                //find second largest


                else if (arr[i] > secMax && arr[i] < max)
                {
                    secMax = arr[i];
                }
            }
        
            //print results
            Console.WriteLine("Largest Element of Array is " + max);
            Console.WriteLine("Second Largest element of Array is " + secMax);

        }
    }
}
