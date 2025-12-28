using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class SpitIntoWords
    {


        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[,] result = SplitWordsWithLengths(text);

            // print result
            for (int i = 0; i < result.GetLength(0); i++)
            {
                Console.WriteLine(result[i, 0] + " -> " + result[i, 1]);
            }
        }

        // create method to split text into words 
        public static string[,] SplitWordsWithLengths(string text)
        {
            List<string> words = new List<string>();
            string currentWord = "";

            for (int i = 0; i < GetStringLength(text); i++)
            {
                if (text[i] != ' ')
                {
                    currentWord += text[i];
                }
                else if (currentWord != "")
                {
                    words.Add(currentWord);
                    currentWord = "";
                }
            }

            // Add last word
            if (currentWord != "")
            {
                words.Add(currentWord);
            }

            // Create 2D array [word, length]
            string[,] result = new string[words.Count, 2];

            for (int i = 0; i < words.Count; i++)
            {
                result[i, 0] = words[i];
                result[i, 1] = GetStringLength(words[i]).ToString();
            }

            return result;
        }

        // create method to calculate string length
        static int GetStringLength(string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                count++;
            }
            return count;
        }
    }
}