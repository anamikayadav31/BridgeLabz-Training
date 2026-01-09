using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class QueueUsingTwoStacks
    {   //stackEnqueue-  stores incoming elements
        //stackDequeue - helps reverse order for dequeue
        private Stack<int> stackEnqueue = new Stack<int>();
        private Stack<int> stackDequeue = new Stack<int>();

        // Enqueue operation
        public void Enqueue(int data)
        {
            //new element is pushed into stackEnqueue
            stackEnqueue.Push(data);
        }

        // Dequeue operation
        public int Dequeue()
        {
            //if both stacks are empty, queue is empty
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");
            //If stackDequeue is empty:Move all elements from stackEnqueue to stackDequeue
            if (stackDequeue.Count == 0)
            {
                while (stackEnqueue.Count > 0)
                {
                    stackDequeue.Push(stackEnqueue.Pop());
                }
            }
           // Pop from stackDequeue return elements( FIFO order)
            return stackDequeue.Pop();
        }

        // Check if queue is empty
        public bool IsEmpty()
        {
            return stackEnqueue.Count == 0 && stackDequeue.Count == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            QueueUsingTwoStacks queue = new QueueUsingTwoStacks();

            // Taking number of elements from user
            Console.Write("Enter number of elements to enqueue: ");
            int n =int.Parse(Console.ReadLine());

            // Enqueue elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element: ");
                int value = int.Parse(Console.ReadLine());
                queue.Enqueue(value);
            }

            Console.WriteLine("\nDequeuing elements:");

            // Dequeue elements until queue becomes empty
            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}