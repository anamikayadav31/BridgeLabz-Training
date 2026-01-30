using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.dataStructures.timeAndSpaceComplexity
{
    internal class StringConcatenationPerformance
    {
        public static void Main(string[] args)
        {
            int n = 10000;
            Stopwatch sw = new Stopwatch();

            // Using String (slow)
            sw.Start();
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s = s + "a";
            }
            sw.Stop();
            Console.WriteLine("String Time: " + sw.ElapsedMilliseconds + " ms");

            // Using StringBuilder (fast)
            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append("a");
            }
            sw.Stop();
            Console.WriteLine("StringBuilder Time: " + sw.ElapsedMilliseconds + " ms");

            Console.WriteLine("\nConclusion:");
            Console.WriteLine("StringBuilder is faster than String for concatenation.");
        }
    }

}

