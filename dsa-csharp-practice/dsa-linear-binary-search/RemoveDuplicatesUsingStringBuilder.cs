//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.StringBuilderBinarySearchLinearSearch
//{
//    internal class RemoveDuplicatesUsingStringBuilder
//    {

//        static void Main()
//        {
//            // Read input string
//            Console.Write("Enter string: ");
//            string input = Console.ReadLine();

//            // StringBuilder to store unique characters
//            StringBuilder result = new StringBuilder();

//            // Loop through each character of input
//            for (int i = 0; i < input.Length; i++)
//            {
//                bool isDuplicate = false;

//                // Check if character already exists in result
//                for (int j = 0; j < result.Length; j++)
//                {
//                    if (input[i] == result[j])
//                    {
//                        isDuplicate = true;
//                        break;
//                    }
//                }

//                // Add character only if not duplicate
//                if (!isDuplicate)
//                {
//                    result.Append(input[i]);
//                }
//            }

//            // Display final string
//            Console.WriteLine("After removing duplicates: " + result);
//        }
//    }
//}
