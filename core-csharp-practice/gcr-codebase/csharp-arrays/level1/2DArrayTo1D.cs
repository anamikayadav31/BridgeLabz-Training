using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level1
{
    internal class _2DArrayTo1D
    {
        public static void Main(string[] args)
        {//ask user to input rows
            int rows = int.Parse(Console.ReadLine());
            //ask user to input columns
            int column = int.Parse(Console.ReadLine());
            //create a 2d array
            int[,] arr = new int[rows, column];
            for (int i=0;i<rows;i++)
            {
                for (int j=0;j<column;j++)
                {
                    arr[i,j] = int.Parse(Console.ReadLine());
                }
            }
            int[] array = new int[rows*column];
            int index=0;
            // Copy elements from 2D array to 1D array
            for (int i=0;i<rows;i++)
            {
                for (int j=0;j<column;j++)
                {
                    array[index] = arr[i, j];
                    index++;
                }
            }
            // Print 1D array
            Console.WriteLine("Elements in 1D Array:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] +" ");
            }
        }
    }
}

