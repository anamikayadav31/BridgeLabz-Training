using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class CheckAgeAndHeight
    {

        public static void Main(string[] args)
        {
            string[] names = { "Amar", "Akbar", "Anthony" };
            int[] ages = new int[3];
            double[] heights = new double[3];
            // user input for ages and heights
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter age of " + names[i] + ":");
                ages[i] = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter height of " + names[i] + " (in cm):");
                heights[i] = double.Parse(Console.ReadLine());
            }
            // find youngest friend
            string youngest = FindYoungest(names, ages);
            Console.WriteLine("The youngest friend is " + youngest);
            // find tallest friend
            string tallest = FindTallest(names, heights);
            Console.WriteLine("The tallest friend is " + tallest);
        }

        //create method to find youngest
        public static string FindYoungest(string[] names, int[] ages)
        {
            int minAge = ages[0];
            int index = 0;

            for (int i = 1; i < ages.Length; i++)
            {
                if (ages[i] < minAge)
                {
                    minAge = ages[i];
                    index = i;
                }
            }

            return names[index];
        }

        // create method to find tallest 
        public static string FindTallest(string[] names, double[] heights)
        {
            double maxHeight = heights[0];
            int index = 0;

            for (int i = 1; i < heights.Length; i++)
            {
                if (heights[i] > maxHeight)
                {
                    maxHeight = heights[i];
                    index = i;
                }
            }

            return names[index];
        }

    }
}


