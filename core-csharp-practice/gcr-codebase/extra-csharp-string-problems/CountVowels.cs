using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class CountVowels
    

    {
        public static void Main(string[] args)
        {
            //ask user to input string
            string input = Console.ReadLine();

            int vCount = 0;
            int cCount = 0;

            // Convert input to lowercase to simplify comparison
            string lowerInput = input.ToLower();

            foreach (char c in lowerInput)
            {
                if (char.IsLetter(c)) // Only consider alphabetic characters
                {
                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    {
                        vCount++;
                    }
                    else
                    {
                        cCount++;
                    }
                }
            }

            Console.WriteLine($"Number of vowels: {vCount}");
            Console.WriteLine($"Number of consonants: {cCount}");
        }
    }

}
