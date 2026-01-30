/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{
    
        class BookNode
        {
            public int BookId;
            public string Title;
            public string Author;
            public string Genre;
            public bool IsAvailable;
            public BookNode Next;
            public BookNode Prev;

            // constructor
            public BookNode(int id, string title, string author, string genre, bool status)
            {
                BookId = id;
                Title = title;
                Author = author;
                Genre = genre;
                IsAvailable = status;
                Next = null;
                Prev = null;
            }
        }

        // Doubly linked list
        class Library
        {
            private BookNode head;
            private BookNode tail;

            // add book at beginning
            public void AddAtBeginning(BookNode newBook)
            {
                if (head == null)
                {
                    head = tail = newBook;
                    return;
                }

                newBook.Next = head;
                head.Prev = newBook;
                head = newBook;
            }

            // add book at end
            public void AddAtEnd(BookNode newBook)
            {
                if (tail == null)
                {
                    head = tail = newBook;
                    return;
                }

                tail.Next = newBook;
                newBook.Prev = tail;
                tail = newBook;
            }

            // add book at position
            public void AddAtPosition(int position, BookNode newBook)
            {
                if (position <= 1)
                {
                    AddAtBeginning(newBook);
                    return;
                }

                BookNode temp = head;
                int count = 1;

                while (temp != null && count < position - 1)
                {
                    temp = temp.Next;
                    count++;
                }

                if (temp == null || temp.Next == null)
                {
                    AddAtEnd(newBook);
                    return;
                }

                newBook.Next = temp.Next;
                newBook.Prev = temp;
                temp.Next.Prev = newBook;
                temp.Next = newBook;
            }

            // remove book by id
            public void RemoveById(int id)
            {
                BookNode temp = head;

                while (temp != null)
                {
                    if (temp.BookId.Equals(id))
                    {
                        if (temp.Prev != null)
                            temp.Prev.Next = temp.Next;
                        else
                            head = temp.Next;

                        if (temp.Next != null)
                            temp.Next.Prev = temp.Prev;
                        else
                            tail = temp.Prev;

                        Console.WriteLine("Book removed");
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Book not found");
            }

            // search by title or author
            public void Search(string key)
            {
                BookNode temp = head;

                while (temp != null)
                {
                    if (temp.Title.Equals(key, StringComparison.OrdinalIgnoreCase) ||
                        temp.Author.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        DisplayBook(temp);
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Book not found");
            }

            // update availability
            public void UpdateAvailability(int id, bool status)
            {
                BookNode temp = head;

                while (temp != null)
                {
                    if (temp.BookId.Equals(id))
                    {
                        temp.IsAvailable = status;
                        Console.WriteLine("Status updated");
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Book not found");
            }

            // display forward
            public void DisplayForward()
            {
                BookNode temp = head;

                if (temp == null)
                {
                    Console.WriteLine("Library is empty");
                    return;
                }

                while (temp != null)
                {
                    DisplayBook(temp);
                    temp = temp.Next;
                }
            }

            // display reverse
            public void DisplayReverse()
            {
                BookNode temp = tail;

                if (temp == null)
                {
                    Console.WriteLine("Library is empty");
                    return;
                }

                while (temp != null)
                {
                    DisplayBook(temp);
                    temp = temp.Prev;
                }
            }

            // count books
            public void CountBooks()
            {
                int count = 0;
                BookNode temp = head;

                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }

                Console.WriteLine("Total books: " + count);
            }

            // show single book
            private void DisplayBook(BookNode b)
            {
                Console.WriteLine(
                    $"ID:{b.BookId}, Title:{b.Title}, Author:{b.Author}, Genre:{b.Genre}, Available:{b.IsAvailable}");
            }
        }

        // Main class
        internal class LibraryManagement
        {
            public static void Main(string[] args)
            {
                Library library = new Library();
                int choice;

                do
                {
                    Console.WriteLine("\n Library Menu ");
                    Console.WriteLine("1 Add Book at Beginning");
                    Console.WriteLine("2 Add Book at End");
                    Console.WriteLine("3 Add Book at Position");
                    Console.WriteLine("4 Remove Book");
                    Console.WriteLine("5 Search Book");
                    Console.WriteLine("6 Update Availability");
                    Console.WriteLine("7 Display Forward");
                    Console.WriteLine("8 Display Reverse");
                    Console.WriteLine("9 Count Books");
                    Console.WriteLine("0 Exit");
                    Console.Write("Choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            library.AddAtBeginning(ReadBook());
                            break;

                        case 2:
                            library.AddAtEnd(ReadBook());
                            break;

                        case 3:
                            Console.Write("Position: ");
                            int pos = Convert.ToInt32(Console.ReadLine());
                            library.AddAtPosition(pos, ReadBook());
                            break;

                        case 4:
                            Console.Write("Book ID: ");
                            library.RemoveById(Convert.ToInt32(Console.ReadLine()));
                            break;

                        case 5:
                            Console.Write("Title or Author: ");
                            library.Search(Console.ReadLine());
                            break;

                        case 6:
                            Console.Write("Book ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Available (true/false): ");
                            bool status = Convert.ToBoolean(Console.ReadLine());
                            library.UpdateAvailability(id, status);
                            break;

                        case 7:
                            library.DisplayForward();
                            break;

                        case 8:
                            library.DisplayReverse();
                            break;

                        case 9:
                            library.CountBooks();
                            break;
                    }

                } while (!choice.Equals(0));
            }

            // read book details
            static BookNode ReadBook()
            {
                Console.Write("Book ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Author: ");
                string author = Console.ReadLine();

                Console.Write("Genre: ");
                string genre = Console.ReadLine();

                Console.Write("Available (true/false): ");
                bool status = Convert.ToBoolean(Console.ReadLine());

                return new BookNode(id, title, author, genre, status);
            }
        }
    }*/
