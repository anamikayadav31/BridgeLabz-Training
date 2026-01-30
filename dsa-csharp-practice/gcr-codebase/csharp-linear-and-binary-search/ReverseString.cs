using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class ReverseString
    {
        public static void Main(string[] args)
            {
                // Ask user to enter a string
                Console.Write("Enter a word or sentence: ");
                string input = Console.ReadLine();

                // Create empty StringBuilder for reversed string
                StringBuilder reversed = new StringBuilder();

                // Loop from last character to first
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed.Append(input[i]); // add character one by one
                }

                Console.WriteLine("Reversed string: " + reversed.ToString());
            }
        }
    }




