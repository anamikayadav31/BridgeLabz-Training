using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class ReplaceWord
    {
      

        public static void Main(string[] args)
        {
            
            //ask user to input string
            string  s = Console.ReadLine();

            //ask user to input a word
            string oldWord = Console.ReadLine();

            //ask user to input the word by that he wants to replaced by
            string newWord = Console.ReadLine();
            //call method
            string result = Replace( s, oldWord, newWord);

            Console.WriteLine("Modified Sentence: " + result);
        }

        public static string Replace(string  s, string oldWord, string newWord)
        {
            string[] words =  s.Split(' '); // Split sentence into words
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == oldWord)
                {
                    words[i] = newWord;
                }
            }

            return string.Join(" ", words); // Join words back into a sentence
        }
    }

}

