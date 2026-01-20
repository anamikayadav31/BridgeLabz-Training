using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{
    internal class NthNode
    {
  
        
        static string FindNthFromEnd(LinkedList<string> list, int n)
        {
            // Pointer 1 starts at the first node
            LinkedListNode<string> first = list.First;

            // Pointer 2 also starts at the first node
            LinkedListNode<string> second = list.First;

            // Move first pointer n steps ahead
            for (int i = 0; i < n; i++)
            {
                // If list has fewer than n elements
                if (first == null)
                {
                    return "N is greater than the number of elements.";
                }
                first = first.Next;
            }

            // Move both pointers until first reaches the end
            while (first != null)
            {
                first = first.Next;
                second = second.Next;
            }

            // second now points to the Nth element from the end
            return second.Value;
        }

        static void Main()
        {
            Console.WriteLine("Enter elements of the LinkedList (space separated):");
            string[] input = Console.ReadLine().Split(' ');

            LinkedList<string> list = new LinkedList<string>();

            // Add input elements to LinkedList
            foreach (string item in input)
            {
                list.AddLast(item);
            }

            Console.WriteLine("Enter N:");
            int n = int.Parse(Console.ReadLine());

            string result = FindNthFromEnd(list, n);

            Console.WriteLine("Nth element from the end:");
            Console.WriteLine(result);
        }
    }

}
