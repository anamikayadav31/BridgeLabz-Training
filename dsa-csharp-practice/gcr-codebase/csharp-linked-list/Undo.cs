using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{
        // node for text state
        class TextNode
        {
            public string Content;
            public TextNode Prev;
            public TextNode Next;

            public TextNode(string text)
            {
                Content = text;
                Prev = null;
                Next = null;
            }
        }

        // editor logic
        class TextEditor
        {
            private TextNode head;
            private TextNode tail;
            private TextNode current;
            private int size;
            private int limit = 10;

            // add new text state
            public void AddState(string text)
            {
                TextNode newNode = new TextNode(text);

                if (head == null)
                {
                    head = tail = current = newNode;
                    size = 1;
                    return;
                }

                // clear redo states
                if (current.Next != null)
                {
                    current.Next.Prev = null;
                    current.Next = null;
                    tail = current;
                    size = CountNodes();
                }

                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
                current = newNode;
                size++;

                // limit history
                if (size > limit)
                    RemoveFirst();
            }

            // undo action
            public void UndoAction()
            {
                if (current != null && current.Prev != null)
                {
                    current = current.Prev;
                    Console.WriteLine("Undo performed");
                }
                else
                {
                    Console.WriteLine("No undo available");
                }
            }

            // redo action
            public void RedoAction()
            {
                if (current != null && current.Next != null)
                {
                    current = current.Next;
                    Console.WriteLine("Redo performed");
                }
                else
                {
                    Console.WriteLine("No redo available");
                }
            }

            // show current text
            public void DisplayCurrent()
            {
                if (current == null)
                {
                    Console.WriteLine("Text is empty");
                    return;
                }

                Console.WriteLine("Current Text: " + current.Content);
            }

            // remove oldest state
            private void RemoveFirst()
            {
                if (head != null)
                {
                    head = head.Next;
                    if (head != null)
                        head.Prev = null;

                    size--;
                }
            }

            // count nodes
            private int CountNodes()
            {
                int count = 0;
                TextNode temp = head;

                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }

                return count;
            }
        }

        // MAIN CLASS
        class Undo
        {
            public static void Main(string[] args)
            {
                TextEditor editor = new TextEditor();
                int choice;

                do
                {
                    Console.WriteLine("\nText Editor Menu");
                    Console.WriteLine("1 Add Text");
                    Console.WriteLine("2 Undo");
                    Console.WriteLine("3 Redo");
                    Console.WriteLine("4 Display Current Text");
                    Console.WriteLine("0 Exit");
                    Console.Write("Choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter text: ");
                            editor.AddState(Console.ReadLine());
                            break;

                        case 2:
                            editor.UndoAction();
                            break;

                        case 3:
                            editor.RedoAction();
                            break;

                        case 4:
                            editor.DisplayCurrent();
                            break;
                    }

                } while (!choice.Equals(0));
            }
        }
    }


