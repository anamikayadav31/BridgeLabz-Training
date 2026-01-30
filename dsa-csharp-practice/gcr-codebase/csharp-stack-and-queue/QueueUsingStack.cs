using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    
class QueueUsingStacks
    {
        // Stack used to add elements
        Stack<int> stackEnqueue = new Stack<int>();

        // Stack used to remove elements
        Stack<int> stackDequeue = new Stack<int>();

        // Add element to queue
        public void Enqueue(int value)
        {
            stackEnqueue.Push(value);
        }

        // Remove element from queue
        public int Dequeue()
        {
            // If both stacks are empty
            if (stackEnqueue.Count == 0 && stackDequeue.Count == 0)
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }

            // Move elements if dequeue stack is empty
            if (stackDequeue.Count == 0)
            {
                while (stackEnqueue.Count > 0)
                {
                    stackDequeue.Push(stackEnqueue.Pop());
                }
            }

            return stackDequeue.Pop();
        }
    }

    internal class QueueUsingStack
    {
        public static void Main(string[] args)
        {
            QueueUsingStacks queue = new QueueUsingStacks();

            Console.Write("How many elements do you want to add: ");
            int n = int.Parse(Console.ReadLine());

            // Taking input from user
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter value: ");
                int value = int.Parse(Console.ReadLine());
                queue.Enqueue(value);
            }

            Console.WriteLine("\nReturn elements of queue:");

           for (int i = 0; i < n; i++)
            {
                int removed = queue.Dequeue();
                if (removed != -1)
                {
                    Console.WriteLine(removed);
                }
            }
        }
    }

}

