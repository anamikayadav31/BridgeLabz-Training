//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace BridgeLabzTraining.Collections.collections_problems
//{
//    internal class WordFrequency
//    {
       

//        static void Main()
//        {
//            Console.Write("Enter the path of the text file: ");
//            string filePath = Console.ReadLine();

//            if (!File.Exists(filePath))
//            {
//                Console.WriteLine("File not found!");
//                return;
//            }

//            string text = File.ReadAllText(filePath);

//            // Convert to lowercase and remove punctuation
//            text = text.ToLower();
//            text = Regex.Replace(text, @"[^\w\s]", ""); // remove punctuation

//            string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

//            Dictionary<string, int> wordCount = new Dictionary<string, int>();

//            foreach (var word in words)
//            {
//                if (wordCount.ContainsKey(word))
//                    wordCount[word]++;
//                else
//                    wordCount[word] = 1;
//            }

//            Console.WriteLine("\nWord Frequencies:");
//            foreach (var kvp in wordCount)
//            {
//                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
//            }
//        }
//    }


//}
