using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.timeAndSpaceComplexity
{
    internal class StringConcatenationPerformance
    {

        static void Main()
        {
            // Ask user for the number of strings to concatenate
            Console.WriteLine("Enter the number of strings to concatenate:");
            int n = int.Parse(Console.ReadLine());

            // Create sample strings (like "a", "b", "c"...) for concatenation
            string[] data = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter string {i + 1}");
                data[i] = Console.ReadLine(); // simple string to keep it fast
            }


            // Using String (Immutable)
           

            Stopwatch sw = Stopwatch.StartNew(); // Start timer
            string resultString = ""; // Empty string to start
            for (int i = 0; i < n; i++)
            {
                resultString += data[i]; // Each + creates a new string
            }
            sw.Stop(); // Stop timer

            Console.WriteLine("\nResult using string (first 50 chars):");
            Console.WriteLine(resultString.Substring(0, Math.Min(50, resultString.Length)) + "...");
            Console.WriteLine($"Time taken (string): {sw.ElapsedMilliseconds} ms");


            // Using StringBuilder (Mutable)
         

            sw.Restart(); // Restart timer
            StringBuilder sb = new StringBuilder(); // Create mutable string builder
            for (int i = 0; i < n; i++)
            {
                sb.Append(data[i]);
            }
            sw.Stop(); // Stop timer

            string resultSB = sb.ToString(); // Convert to string
            Console.WriteLine("\nResult using StringBuilder (first 50 chars):");
            Console.WriteLine(resultSB.Substring(0, Math.Min(50, resultSB.Length)) + "...");
            Console.WriteLine($"Time taken (StringBuilder): {sw.ElapsedMilliseconds} ms");

          

            // Optional: Compare both
           

            Console.WriteLine("\nComparison:");
            Console.WriteLine($"String length: {resultString.Length}, StringBuilder length: {resultSB.Length}");
        }
    }

}
