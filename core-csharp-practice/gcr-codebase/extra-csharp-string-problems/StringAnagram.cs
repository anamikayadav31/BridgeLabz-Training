using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class StringAnagram
    {
        

        public static void Main(string[] args)
        {
            //ask user to input two strings
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            if (AreAnagrams(str1, str2))
            {
                Console.WriteLine("The strings are anagrams of each other.");
            }
            else
            {
                Console.WriteLine("The strings are NOT anagrams of each other.");
            }
        }

        public static bool AreAnagrams(string s1, string s2)
        {
            // Remove spaces and convert to lowercase 
            s1 = s1.Replace(" ", "").ToLower();
            s2 = s2.Replace(" ", "").ToLower();

            // If lengths are different, they cannot be anagrams
            if (s1.Length != s2.Length)
                return false;

            // Count frequency of characters in s1
            int[] charCount = new int[256]; 
            foreach (char c in s1)
            {
                charCount[c]++;
            }

            
            foreach (char c in s2)
            {
                charCount[c]--;
            }

            // If all counts are 0, they are anagrams
            foreach (int count in charCount)
            {
                if (count != 0)
                    return false;
            }

            return true;
        }
    }

}

