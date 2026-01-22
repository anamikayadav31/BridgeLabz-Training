using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class CountWords
    {
   

        static void Main()
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                Dictionary<string, int> wordCount = new Dictionary<string, int>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    // Read file line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split line into words
                        string[] words = line.ToLower()
                                              .Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' },
                                                     StringSplitOptions.RemoveEmptyEntries);

                        // Count words
                        foreach (string word in words)
                        {
                            if (wordCount.ContainsKey(word))
                                wordCount[word]++;
                            else
                                wordCount[word] = 1;
                        }
                    }
                }

                // Sort and get top 5 words
                var topWords = wordCount
                               .OrderByDescending(w => w.Value)
                               .Take(5);

                Console.WriteLine("\nTop 5 Most Frequent Words:");
                foreach (var word in topWords)
                {
                    Console.WriteLine($"{word.Key} : {word.Value}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
        }
    }

}
