/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{
    internal class ReverseAList
    {

        // Method to reverse an ArrayList without using built-in methods
        static void ReverseArrayList(ArrayList list)
        {
            int start = 0;
            int end = list.Count - 1;

            // Swap elements from both ends until the middle is reached
            while (start < end)
            {
                object temp = list[start];
                list[start] = list[end];
                list[end] = temp;

                start++;
                end--;
            }
        }

        // Method to reverse a LinkedList
        static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
        {
            LinkedList<int> reversedList = new LinkedList<int>();

            // Add each element to the beginning of the new list
            foreach (int item in list)
            {
                reversedList.AddFirst(item);
            }

            return reversedList;
        }

        static void Main()
        {
            // ----------- ARRAYLIST INPUT -----------
            Console.WriteLine("Enter numbers for ArrayList (space separated):");
            string[] inputArray = Console.ReadLine().Split(' ');

            ArrayList arrayList = new ArrayList();

            // Convert input strings to integers and add to ArrayList
            foreach (string item in inputArray)
            {
                arrayList.Add(int.Parse(item));
            }

            // Reverse ArrayList
            ReverseArrayList(arrayList);

            Console.WriteLine("Reversed ArrayList:");
            Console.WriteLine(string.Join(", ", arrayList));

            // ----------- LINKEDLIST INPUT -----------
            Console.WriteLine("\nEnter numbers for LinkedList (space separated):");
            string[] inputLinked = Console.ReadLine().Split(' ');

            LinkedList<int> linkedList = new LinkedList<int>();

            // Convert input strings to integers and add to LinkedList
            foreach (string item in inputLinked)
            {
                linkedList.AddLast(int.Parse(item));
            }

            // Reverse LinkedList
            LinkedList<int> reversedLinkedList = ReverseLinkedList(linkedList);

            Console.WriteLine("Reversed LinkedList:");
            Console.WriteLine(string.Join(", ", reversedLinkedList));
        }
    }
}*/