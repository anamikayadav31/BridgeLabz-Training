using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class RemoveDuplicates
    {
            public static void Main(string[] args)
            {
                // Ask user to enter a string
                Console.Write("Enter a word or sentence: ");
                string input = Console.ReadLine();

                // StringBuilder to store result 
                StringBuilder result = new StringBuilder();

                // Loop through each character in the string
                for (int i = 0; i < input.Length; i++)
                {
                    char currentChar = input[i];

                    // Check if character is already present in result
                    if (!result.ToString().Contains(currentChar))
                    {
                        result.Append(currentChar); // add only unique character
                    }
                }

                Console.WriteLine("String without duplicates: " + result.ToString());
            }
        }
    }


