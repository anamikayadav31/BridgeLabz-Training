using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{



    // Node class for text state
    class TextNode
    {
        public string Content;
        public TextNode Prev, Next;

        // Constructor
        public TextNode(string content)
        {
            Content = content;
            Prev = Next = null;
        }
    }

    // Doubly Linked List for Undo/Redo
    class TextHistory
    {
        private TextNode head, tail, current;
        private int size = 0;
        private const int MAX_SIZE = 10;

        // Add new text state
        public void AddState(string content)
        {
            TextNode node = new TextNode(content);

            // Remove forward history if new text added after undo
            if (current != null && current.Next != null)
            {
                current.Next = null;
                tail = current;
            }

            if (head == null)
            {
                head = tail = current = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
                current = node;
            }

            size++;

            // Limit history size
            if (size > MAX_SIZE)
            {
                head = head.Next;
                head.Prev = null;
                size--;
            }

            Console.WriteLine("Text updated.");
        }

        // Undo operation
        public void Undo()
        {
            if (current != null && current.Prev != null)
            {
                current = current.Prev;
                Console.WriteLine("Undo performed.");
            }
            else
            {
                Console.WriteLine("No more undo available.");
            }
        }

        // Redo operation
        public void Redo()
        {
            if (current != null && current.Next != null)
            {
                current = current.Next;
                Console.WriteLine("Redo performed.");
            }
            else
            {
                Console.WriteLine("No more redo available.");
            }
        }

        // Display current text
        public void DisplayCurrent()
        {
            if (current == null)
                Console.WriteLine("Editor empty.");
            else
                Console.WriteLine("Current Text: " + current.Content);
        }
    }

    // MAIN CLASS
    class TextEditor
    {
        static void Main()
        {
            TextHistory editor = new TextHistory();
            int choice;

            do
            {
                Console.WriteLine("\n--- Text Editor ---");
                Console.WriteLine("1. Type / Add Text");
                Console.WriteLine("2. Undo");
                Console.WriteLine("3. Redo");
                Console.WriteLine("4. Display Current Text");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter text: ");
                        editor.AddState(Console.ReadLine());
                        break;

                    case 2:
                        editor.Undo();
                        break;

                    case 3:
                        editor.Redo();
                        break;

                    case 4:
                        editor.DisplayCurrent();
                        break;
                }

            } while (choice != 0);
        }
    }
}