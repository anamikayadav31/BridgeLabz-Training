using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class StringBuilderPerformance
    {
        public static void Main(string[] args)
        {
            // Ask user for number of repetitions
            Console.Write("Enter how many times string should be added: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("\nChecking performance\n");

            // Normal String 
            string text = "";

            DateTime start1 = DateTime.Now;

            for (int i = 0; i < n; i++)
            {
                text = text + "Hello";
            }

            DateTime end1 = DateTime.Now;
            TimeSpan time1 = end1 - start1;

            Console.WriteLine("Time taken using String: " + time1);

            // StringBuilder
            StringBuilder sb = new StringBuilder();

            DateTime start2 = DateTime.Now;

            for (int i = 0; i < n; i++)
            {
                sb.Append("Hello");
            }

            DateTime end2 = DateTime.Now;
            TimeSpan time2 = end2 - start2;

            Console.WriteLine("Time taken using StringBuilder: " + time2);

            Console.WriteLine("\nConclusion:");
            Console.WriteLine("StringBuilder works faster for repeated string operations.");
        }
    }
}

