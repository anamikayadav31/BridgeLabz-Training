using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class FindLongWord
    {
      

        public static void Main(string[] args)
        {
           
            //ask user to take a string 
            string  s = Console.ReadLine();

            // Split the string
            string[] words =  s.Split(' ');

            string longestWord = "";
            int  max = 0;

            foreach (string word in words)
            {
                // Check length of the current word
                if (word.Length >  max)
                {
                     max = word.Length;
                    longestWord = word;
                }
            }

            Console.WriteLine("The longest word is: " + longestWord);
        }
    }

}
