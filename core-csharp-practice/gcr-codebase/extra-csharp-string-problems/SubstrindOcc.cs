using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class SubstrindOcc
    {

        public static void Main(string[] args)
        {
            
            //ask user to input a string
            string s = Console.ReadLine();

           //ask user to input substring 
            string subString = Console.ReadLine();

            int count = 0;
            int index = 0;

            // Loop to find all occurrences of the substring
            while ((index =  s.IndexOf(subString, index)) != -1)
            {
                count++;
                index += subString.Length;
            }

            Console.WriteLine("The substring " + subString + " occurs " + count + " times.");

        }
    }

}
