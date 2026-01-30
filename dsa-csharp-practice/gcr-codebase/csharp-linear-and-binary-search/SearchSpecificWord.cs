using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class SearchSpecificWord
    {
            public static void Main(string[] args)
            {
                // Ask user for number of sentences
                Console.Write("Enter number of sentences: ");
                int n = int.Parse(Console.ReadLine());

                string[] sentences = new string[n];

                // Read sentences from user
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter sentence " + (i + 1) + ": ");
                    sentences[i] = Console.ReadLine();
                }

                // Word to search
                Console.Write("Enter word to search: ");
                string word = Console.ReadLine();

                // Linear search through each sentence
                for (int i = 0; i < sentences.Length; i++)
                {
                    // Check each position in the sentence
                    for (int j = 0; j <= sentences[i].Length - word.Length; j++)
                    {
                        int k;

                        // Compare characters of word
                        for (k = 0; k < word.Length; k++)
                        {
                            if (sentences[i][j + k] != word[k])
                                break;
                        }

                        // If full word matched
                        if (k == word.Length)
                        {
                            Console.WriteLine("Word found in sentence: ");
                            Console.WriteLine(sentences[i]);
                            return; // Stop search after first match
                        }
                    }
                }

                // If word not found in any sentence
                Console.WriteLine("Word not found in any sentence");
            }
        }

    }
