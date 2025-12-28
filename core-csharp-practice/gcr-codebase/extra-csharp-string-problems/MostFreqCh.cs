using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class MostFreqCh
    {


        public static void Main(string[] args)
        {
            //ask user to input a string
            string s = Console.ReadLine();

            char mostFrequent = FindMostFrequent(s);

            Console.WriteLine("Most Frequent Character: " + mostFrequent);
        }

        public static char FindMostFrequent(string s)
        {

            int[] frequency = new int[256];

            // Count frequency of each character
            foreach (char c in s)
            {
                frequency[c]++;

            }
        }
    }
}
      