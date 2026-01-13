//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace BridgeLabzTraining.DataStructuresAndAlgorithm.StringBuilderBinarySearchLinearSearch
//{
//    internal class CompareStringBuilderPerformance
//    {
        

//        static void Main()
//        {
//            Stopwatch sw = new Stopwatch();

//            // Using String (slow)
//            sw.Start();
//            string s = "";
//            for (int i = 0; i < 5000; i++)
//            {
//                s = s + "a"; // Creates new object each time
//            }
//            sw.Stop();
//            Console.WriteLine("String Time: " + sw.ElapsedMilliseconds + " ms");

//            // Using StringBuilder (fast)
//            sw.Restart();
//            StringBuilder sb = new StringBuilder();
//            for (int i = 0; i < 5000; i++)
//            {
//                sb.Append("a"); // Modifies same object
//            }
//            sw.Stop();
//            Console.WriteLine("StringBuilder Time: " + sw.ElapsedMilliseconds + " ms");
//        }
//    }

//}
