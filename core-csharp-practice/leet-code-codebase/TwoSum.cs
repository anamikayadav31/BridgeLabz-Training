using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.leetcode
{
    internal class TwoSum
    {
        public static void Main(string[] args)
        {//ask user to input size of array
            int n = int.Parse(Console.ReadLine());
            //create array to store input elements
            int[] arr = new int[n];
            //create array to store results
            int[] res = new int[2];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            //input target 
            int target = int.Parse(Console.ReadLine());
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {//check condition
                    if (arr[i] + arr[j] == target)
                    {
                        res[0] = i;
                        res[1] = j;
                        //[print indexes
                        Console.WriteLine(res[0] + " " + res[1]);
                        return;
                    }
                }

            }
            

        }
    }
}
