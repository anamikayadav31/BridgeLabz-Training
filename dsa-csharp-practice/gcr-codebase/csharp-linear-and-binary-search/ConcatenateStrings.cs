using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class ConcatenateStrings
    {
            public static void Main(string[] args)
            {
                // Ask user for number of strings
                Console.Write("Enter number of strings: ");
                int count = int.Parse(Console.ReadLine());

                // Create StringBuilder to store final result
                StringBuilder sb = new StringBuilder();

                // Take strings one by one
                for (int i = 0; i < count; i++)
                {
                    Console.Write("Enter string " + (i + 1) + ": ");
                    string input = Console.ReadLine();

                    sb.Append(input);      // add string
                    sb.Append(" ");        
                }

                // Display concatenated string
                Console.WriteLine("\nConcatenated String:");
                Console.WriteLine(sb.ToString());
            }
        }
    }


