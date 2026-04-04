/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{
    internal class ReverseQueueProgram

    {
   

        // Recursive method to reverse the queue
        static void ReverseQueue(Queue<int> queue)
        {
            // Base case: if queue is empty, return
            if (queue.Count == 0)
                return;

            // Remove front element
            int front = queue.Dequeue();

            // Reverse remaining queue
            ReverseQueue(queue);

            // Add the removed element to the rear
            queue.Enqueue(front);
        }

        static void Main()
        {
            Console.WriteLine("Enter elements of the queue (space separated):");
            string[] input = Console.ReadLine().Split(' ');

            Queue<int> queue = new Queue<int>();

            // Add input elements to the queue
            foreach (string item in input)
            {
                queue.Enqueue(int.Parse(item));
            }

            // Reverse the queue
            ReverseQueue(queue);

            Console.WriteLine("Reversed Queue:");
            Console.WriteLine(string.Join(", ", queue));
        }
    }

}
*/