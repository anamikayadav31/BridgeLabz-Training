using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{
   


    // Node class
    class BookNode
    {
        public int BookId;
        public string Title;
        public string Author;
        public string Genre;
        public bool IsAvailable;
        public BookNode Prev, Next;

        // Constructor
        public BookNode(int id, string title, string author, string genre, bool available)
        {
            BookId = id;
            Title = title;
            Author = author;
            Genre = genre;
            IsAvailable = available;
            Prev = Next = null;
        }
    }

    // Doubly Linked List class
    class LibraryList
    {
        private BookNode head, tail;

        // Add book at beginning
        public void AddAtBeginning(int id, string title, string author, string genre, bool available)
        {
            BookNode node = new BookNode(id, title, author, genre, available);

            if (head == null)
                head = tail = node;
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
            Console.WriteLine("Book added at beginning.");
        }

        // Add book at end
        public void AddAtEnd(int id, string title, string author, string genre, bool available)
        {
            BookNode node = new BookNode(id, title, author, genre, available);

            if (tail == null)
                head = tail = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            Console.WriteLine("Book added at end.");
        }

        // Add book at specific position
        public void AddAtPosition(int id, string title, string author, string genre, bool available, int pos)
        {
            if (pos <= 1)
            {
                AddAtBeginning(id, title, author, genre, available);
                return;
            }

            BookNode temp = head;
            for (int i = 1; i < pos - 1 && temp != null; i++)
                temp = temp.Next;

            if (temp == null || temp.Next == null)
            {
                AddAtEnd(id, title, author, genre, available);
            }
            else
            {
                BookNode node = new BookNode(id, title, author, genre, available);
                node.Next = temp.Next;
                node.Prev = temp;
                temp.Next.Prev = node;
                temp.Next = node;
                Console.WriteLine("Book added at position " + pos);
            }
        }

        // Remove book by ID
        public void RemoveById(int id)
        {
            BookNode temp = head;

            while (temp != null)
            {
                if (temp.BookId == id)
                {
                    if (temp == head)
                        head = temp.Next;
                    if (temp == tail)
                        tail = temp.Prev;
                    if (temp.Prev != null)
                        temp.Prev.Next = temp.Next;
                    if (temp.Next != null)
                        temp.Next.Prev = temp.Prev;

                    Console.WriteLine("Book removed.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Book not found.");
        }

        // Search book by title or author
        public void Search(string key)
        {
            BookNode temp = head;
            bool found = false;

            while (temp != null)
            {
                if (temp.Title.Equals(key, StringComparison.OrdinalIgnoreCase) ||
                    temp.Author.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    DisplayBook(temp);
                    found = true;
                }
                temp = temp.Next;
            }

            if (!found)
                Console.WriteLine("Book not found.");
        }

        // Update availability status
        public void UpdateAvailability(int id, bool status)
        {
            BookNode temp = head;

            while (temp != null)
            {
                if (temp.BookId == id)
                {
                    temp.IsAvailable = status;
                    Console.WriteLine("Availability updated.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Book not found.");
        }

        // Display books forward
        public void DisplayForward()
        {
            BookNode temp = head;
            if (temp == null)
            {
                Console.WriteLine("Library empty.");
                return;
            }

            while (temp != null)
            {
                DisplayBook(temp);
                temp = temp.Next;
            }
        }

        // Display books reverse
        public void DisplayReverse()
        {
            BookNode temp = tail;
            if (temp == null)
            {
                Console.WriteLine("Library empty.");
                return;
            }

            while (temp != null)
            {
                DisplayBook(temp);
                temp = temp.Prev;
            }
        }

        // Count total books
        public void CountBooks()
        {
            int count = 0;
            BookNode temp = head;

            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            Console.WriteLine("Total books in library: " + count);
        }

        // Display single book
        private void DisplayBook(BookNode b)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Book ID   : " + b.BookId);
            Console.WriteLine("Title     : " + b.Title);
            Console.WriteLine("Author    : " + b.Author);
            Console.WriteLine("Genre     : " + b.Genre);
            Console.WriteLine("Available : " + (b.IsAvailable ? "Yes" : "No"));
        }
    }

    // MAIN CLASS
    class LibraryManagement
    {
        static void Main()
        {
            LibraryList list = new LibraryList();
            int choice;

            do
            {
                Console.WriteLine("\n--- Library Management System ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Update Availability");
                Console.WriteLine("5. Display Forward");
                Console.WriteLine("6. Display Reverse");
                Console.WriteLine("7. Count Books");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Book ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Genre: ");
                        string genre = Console.ReadLine();
                        Console.Write("Available (true/false): ");
                        bool available = bool.Parse(Console.ReadLine());
                        Console.Write("Position (1-Begin, 2-End, else index): ");
                        int pos = int.Parse(Console.ReadLine());

                        if (pos == 1)
                            list.AddAtBeginning(id, title, author, genre, available);
                        else if (pos == 2)
                            list.AddAtEnd(id, title, author, genre, available);
                        else
                            list.AddAtPosition(id, title, author, genre, available, pos);
                        break;

                    case 2:
                        Console.Write("Enter Book ID: ");
                        list.RemoveById(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        Console.Write("Enter Title or Author: ");
                        list.Search(Console.ReadLine());
                        break;

                    case 4:
                        Console.Write("Book ID: ");
                        int bid = int.Parse(Console.ReadLine());
                        Console.Write("Available (true/false): ");
                        bool st = bool.Parse(Console.ReadLine());
                        list.UpdateAvailability(bid, st);
                        break;

                    case 5:
                        list.DisplayForward();
                        break;

                    case 6:
                        list.DisplayReverse();
                        break;

                    case 7:
                        list.CountBooks();
                        break;
                }

            } while (choice != 0);
        }
    }
}
