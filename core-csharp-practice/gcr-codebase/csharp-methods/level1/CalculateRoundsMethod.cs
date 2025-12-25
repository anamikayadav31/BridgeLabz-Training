using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class CalculateRoundsMethod
    {
        public static void Main(string[] args)
        {//ask user to input sides of triangle
            int s1 = int.Parse(Console.ReadLine());
            int s2 = int.Parse(Console.ReadLine());
            int s3 = int.Parse(Console.ReadLine());
            //distance is given
            int distance = 5;
            //call method
            Console.WriteLine(FindRounds(s1, s2, s3, distance));
        }
        //create a method to find no. of rounds
        public static int FindRounds(int s1, int s2, int s3, int distance)
        {//compute perimeter of triangle
            int peri = s1 + s2 + s3;
            //compute rounds
            int rounds = peri/distance;
            //return 
            return rounds;
        }
    }
}
