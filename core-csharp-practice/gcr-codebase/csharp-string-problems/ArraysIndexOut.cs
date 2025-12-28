using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class ArraysIndexOut
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[5];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            try
            {
                int f = arr[arr.Length+1];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(" Caught IndexOutOfRangeException!");
                Console.WriteLine(e.Message);
            }

        }




    }
}
