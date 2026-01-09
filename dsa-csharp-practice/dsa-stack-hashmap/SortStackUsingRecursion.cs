using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class SortStackUsingRecursion
    {
    

        // Function to sort the stack
        static void SortStack(Stack<int> stack)
        {
            // Base condition
            if (stack.Count == 0)
                return;

            //  Remove top element
            int top = stack.Pop();

            // Sort remaining stack
            SortStack(stack);

            //  Insert the element back in sorted order
            InsertSorted(stack, top);
        }

        // helper function to insert an element in sorted order
        static void InsertSorted(Stack<int> stack, int element)
        {
            // Base condition
            if (stack.Count == 0 || stack.Peek() <= element)
            {
                stack.Push(element);
                return;
            }

            // Remove top element
            int temp = stack.Pop();

            // Recursive call
            InsertSorted(stack, element);

            // Push back the removed element
            stack.Push(temp);
        }

        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            Console.Write("Enter number of elements in stack: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter stack elements:");
            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                stack.Push(value);
            }

            Console.WriteLine("\nOriginal Stack:");
            foreach (int item in stack)
                Console.Write(item + " ");

            // Sort the stack
            SortStack(stack);

            Console.WriteLine("\n\nSorted Stack:");
            foreach (int item in stack)
                Console.Write(item + " ");
        }
    }

}
