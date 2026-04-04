using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.scenerioBased
{
    internal class SentenceFormatter
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a paragraph:");
            string paragraph = Console.ReadLine();

            // Handle empty or whitespace-only input
            if (string.IsNullOrWhiteSpace(paragraph))
            {
                Console.WriteLine("Empty paragraph.");
                return;
            }

            string corrected = CorrectParagraph(paragraph);
            Console.WriteLine("\nCorrected Paragraph:");
            Console.WriteLine(corrected);

            Console.WriteLine("\nWord count: " + CountWords(corrected));
            Console.WriteLine("Longest word: " + LongestWord(corrected));

            Console.WriteLine("\nEnter word to replace:");
            string from = Console.ReadLine();
            Console.WriteLine("Enter replacement word:");
            string to = Console.ReadLine();

            string replacedParagraph = ReplaceWord(corrected, from, to);
            Console.WriteLine("\nUpdated Paragraph:");
            Console.WriteLine(replacedParagraph);
        }


        public static string CorrectParagraph(string text)
        {
            string result = "";
            bool capitalizeNext = true;
            bool lastWasSpace = false;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                // Skip extra spaces
                if (c == ' ')
                {
                    if (!lastWasSpace)
                    {
                        result += c;
                        lastWasSpace = true;
                    }
                    continue;
                }
                else
                {
                    lastWasSpace = false;
                }

                // Capitalize first letter after punctuation
                if (capitalizeNext && char.IsLetter(c))
                {
                    result += char.ToUpper(c);
                    capitalizeNext = false;
                }
                else
                {
                    result += c;
                }

                // Add space after punctuation if needed
                if (c == '.' || c == '?' || c == '!')
                {
                    capitalizeNext = true;

                    if (i + 1 < text.Length && text[i + 1] != ' ')
                    {
                        result += ' ';
                        lastWasSpace = true;
                    }
                }
            }

            return result.Trim();
        }
        public static string ReplaceWord(string text, string from, string to)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(from))
                return text;

            string result = "";
            string currentWord = "";
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c != ' ')
                {
                    currentWord += c;
                }
                else
                {
                    // Compare ignoring case
                    if (string.Equals(currentWord, from, StringComparison.OrdinalIgnoreCase))
                        result += to;
                    else
                        result += currentWord;

                    result += ' ';
                    currentWord = "";
                }
            }

            // Last word
            if (string.Equals(currentWord, from, StringComparison.OrdinalIgnoreCase))
                result += to;
            else
                result += currentWord;

            return result;
        }
    
        public static int CountWords(string text)
        {
            int count = 0;
            bool inWord = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ' && !inWord)
                {
                    inWord = true;
                    count++;
                }
                else if (text[i] == ' ')
                {
                    inWord = false;
                }
            }

            return count;
        }


        public static string LongestWord(string text)
        { 
            string longest = "";
            string word = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    word += text[i];
                }
                else
                {
                    if (word.Length > longest.Length)
                        longest = word;
                    word = "";
                }
            }
            // Check last word
            if (word.Length > longest.Length)
                longest = word;

            return longest;



            
        }
    }
}
      