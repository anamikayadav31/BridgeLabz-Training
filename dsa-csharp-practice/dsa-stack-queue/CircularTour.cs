/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class CircularTour
    {
   

        static int FindStartingPoint(int[] petrol, int[] distance, int n)
        {
            int start = 0, surplus = 0, deficit = 0;

            for (int i = 0; i < n; i++)
            {
                surplus += petrol[i] - distance[i];

                // If surplus goes negative, reset start
                if (surplus < 0)
                {
                    start = i + 1;
                    deficit += surplus;
                    surplus = 0;
                }
            }

            return (surplus + deficit >= 0) ? start : -1;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter number of petrol pumps: ");
            int n = int.Parse(Console.ReadLine());

            int[] petrol = new int[n];
            int[] distance = new int[n];

            Console.WriteLine("Enter petrol values:");
            for (int i = 0; i < n; i++)
                petrol[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter distance values:");
            for (int i = 0; i < n; i++)
                distance[i] = int.Parse(Console.ReadLine());

            int result = FindStartingPoint(petrol, distance, n);

            if (result == -1)
                Console.WriteLine("No possible circular tour.");
            else
                Console.WriteLine("Start at petrol pump index: " + result);
        }
    }

}
*/