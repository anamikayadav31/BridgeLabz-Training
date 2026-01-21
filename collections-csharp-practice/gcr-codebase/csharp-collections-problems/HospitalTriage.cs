//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.Collections.collections_problems
//{
//    internal class HospitalTriage
//    {
   

//        static void Main()
//        {
//            // PriorityQueue using tuple (Name, Severity)
//            PriorityQueue<(string Name, int Severity), int> triageQueue = new PriorityQueue<(string, int), int>();

//            Console.Write("How many patients? ");
//            int n = int.Parse(Console.ReadLine());

//            for (int i = 0; i < n; i++)
//            {
//                Console.Write($"Enter name of patient {i + 1}: ");
//                string name = Console.ReadLine();

//                Console.Write($"Enter severity of {name} (higher number = more severe): ");
//                int severity = int.Parse(Console.ReadLine());

//                // Negative severity because PriorityQueue dequeues smallest first
//                triageQueue.Enqueue((name, severity), -severity);
//            }

//            Console.WriteLine("\nTreatment order:");

//            while (triageQueue.Count > 0)
//            {
//                var patient = triageQueue.Dequeue();
//                Console.WriteLine($"{patient.Name} (Severity: {patient.Severity})");
//            }
//        }
//    }

//}
