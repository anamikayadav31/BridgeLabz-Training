using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class CompareTwoString
    {
        public static void Main(string[] args)
        {//ask user to input two strings
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            //call the method
            Console.WriteLine(CompareStrings(s1, s2));

        }
        //create a method to compare two strings
        public static bool CompareStrings(string s1, string s2)
        {
            return s1.Equals(s2);
        }
    }
}
