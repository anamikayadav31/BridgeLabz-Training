//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.StringBuilderBinarySearchLinearSearch
//{
//    internal class CountWordInFile
//    {
        

//        static void Main()
//        {
//            // File path input
//            Console.Write("Enter file path: ");
//            string path = Console.ReadLine();

//            // Word to search
//            Console.Write("Enter word: ");
//            string word = Console.ReadLine();

//            // Read complete file content
//            StreamReader reader = new StreamReader(path);
//            string text = reader.ReadToEnd();
//            reader.Close();

//            int count = 0;

//            // Check each position in text
//            for (int i = 0; i <= text.Length - word.Length; i++)
//            {
//                bool match = true;

//                // Compare character by character
//                for (int j = 0; j < word.Length; j++)
//                {
//                    if (text[i + j] != word[j])
//                    {
//                        match = false;
//                        break;
//                    }
//                }

//                // Increase count if word matches
//                if (match)
//                    count++;
//            }

//            Console.WriteLine("Word Count: " + count);
//        }
//    }

//}

