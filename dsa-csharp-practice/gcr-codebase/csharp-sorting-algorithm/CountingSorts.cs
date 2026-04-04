using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.sortingAlgorithm
{
    internal class CountingSorts
    {
       public static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            int[] ages = new int[n];

            // Taking ages input from user
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter age of student " + (i + 1) + ": ");
                ages[i] = int.Parse(Console.ReadLine());
            }

            int[] sortedAges = CountingSort(ages);

            Console.WriteLine("\nSorted Student Ages:");
            foreach (int age in sortedAges)
            {
                Console.Write(age + " ");
            }
        }

        static int[] CountingSort(int[] arr)
        {
            int minAge = 10;
            int maxAge = 18;

            // Count how many times each age occurs
            int[] count = new int[maxAge - minAge + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - minAge]++;
            }

            // Make cumulative count
            for (int i = 1; i < count.Length; i++)
            {
                count[i] = count[i] + count[i - 1];
            }

            // Place ages in correct position
            int[] output = new int[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int age = arr[i];
                int position = count[age - minAge] - 1;
                output[position] = age;
                count[age - minAge]--;
            }

            return output;
        }
    }

}

