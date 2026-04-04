using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class YoungestOfThreeFriends
    {
        public static void Main(string[] args)
        {//create a string array that contains names of three friends
            string[] name = { "Amar", "Akbar", "Anthony" };
            int[] age = new int[3];
            double[] height= new double[3];
            // ask user to input for age and height
            for (int i = 0; i < 3; i++)
            {
                age[i]=int.Parse(Console.ReadLine());
                height[i] = double.Parse(Console.ReadLine());
            }
 //initialise variables with 0
            int youngest= 0;
            int tallest= 0;
            // Find youngest and tallest
            for (int i = 1; i < 3; i++)
            {
                if (age[i]<age[youngest])
                {
                    youngest=i;
                }

                if (height[i]>height[tallest])
                {
                    tallest= i;
                }
            }

            //print resuts
            Console.WriteLine("Youngest Friend is " + name[youngest]);
            Console.WriteLine("Tallest Friend: " + name[tallest]);
                              
        }
    }
}

