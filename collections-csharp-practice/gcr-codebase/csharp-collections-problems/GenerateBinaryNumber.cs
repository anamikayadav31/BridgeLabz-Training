//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.Collections.collections_problems
//{
//    internal class GenerateBinaryNumber
//    {
    
    

//        static void GenerateBinaryNumbers(int n)
//        {
//            Queue<string> queue = new Queue<string>();

//            // Start with binary 1
//            queue.Enqueue("1");

//            Console.WriteLine("First " + n + " binary numbers:");

//            for (int i = 0; i < n; i++)
//            {
//                // Get the front binary number
//                string current = queue.Dequeue();

//                // Print current binary number
//                Console.Write(current + " ");

//                // Generate next binary numbers
//                queue.Enqueue(current + "0");
//                queue.Enqueue(current + "1");
//            }
//        }

//        static void Main()
//        {
//            Console.WriteLine("Enter value of N:");
//            int n = int.Parse(Console.ReadLine());

//            GenerateBinaryNumbers(n);
//        }
//    }

//}
