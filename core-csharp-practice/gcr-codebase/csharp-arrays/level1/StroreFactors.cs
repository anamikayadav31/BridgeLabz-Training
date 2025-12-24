using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    internal class StroreFactors
    {
        public static void Main(string[] args)
        {//ask user to input a number
            int n= int.Parse(Console.ReadLine());
            //initialise maxFactor with 10
            int maxFactor = 10;
            //initialise idx with 0
            int idx = 0;
            //create a array to store factors
            int[] arr = new int[maxFactor];
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {//resize 
                    if (idx == maxFactor)
                    {
                        maxFactor = 2 * maxFactor;
                    }
                    arr[idx] = i;
                    idx++;
                }
            }
            //print
            for (int i = 0; i < idx; i++)
            {
                Console.Write(arr[i] + " ");
            }




        }
    }
}
