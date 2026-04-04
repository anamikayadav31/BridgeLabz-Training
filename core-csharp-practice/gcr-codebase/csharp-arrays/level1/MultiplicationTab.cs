using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    class MultiplicationTab
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //create an array of length 10 
            int[] arr = new int[10];

            //iterate loop 
            for (int i = 1; i <= 10; i++)
            {
                int res = n * i;
                //print table
                Console.WriteLine(n + " x " + i + " = " + res);
                //store in arr
                arr[i-1] = res;
            }
        }
    }
}


