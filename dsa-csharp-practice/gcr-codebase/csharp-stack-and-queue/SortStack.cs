using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    internal class SortStack
    {  
        // Method to sort the stack
        public static void SortStacks(Stack<int> stack)
        {
            // Base condition: if stack is empty
            if (stack.Count == 0)
            {
                return;
            }

            // Remove top element
            int top = stack.Pop();

            // Sort remaining stack
            SortStacks(stack);

            // Insert the removed element in sorted order
            InsertSorted(stack, top);
        }

        // Method to insert element in sorted position
        public static void InsertSorted(Stack<int> stack, int value)
        {
            // If stack is empty OR value is greater than top element
            if (stack.Count == 0 || value > stack.Peek())
            {
                stack.Push(value);
                return;
            }

            // Remove top element
            int temp = stack.Pop();

            // Recursive call
            InsertSorted(stack, value);

            // Put back the removed element
            stack.Push(temp);
        }

       public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            Console.Write("How many elements do you want to push: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter value: ");
                int value = int.Parse(Console.ReadLine());
                stack.Push(value);
            }

            // Sort the stack
            SortStacks(stack);

            Console.WriteLine("\nSorted Stack (Top to Bottom):");

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }

}

