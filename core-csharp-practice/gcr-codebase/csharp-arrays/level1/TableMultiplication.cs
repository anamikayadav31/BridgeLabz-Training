using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    internal class TableMultiplication
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //create an array of length 4
            int[] arr = new int[4];
            int idx = 0;
            //iterate loop 
            for (int i = 6; i <= 9; i++)
            {
                int res = n * i;
                arr[idx] = res;
                //print table
                Console.WriteLine(n + " x " + i + " = " + res);
                //store in arr
                idx++;
            }
        }
    }
}
