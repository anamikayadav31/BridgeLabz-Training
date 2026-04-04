using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.oopsKeywordsOperator
{
    internal class LibrarySystem
    {



        // Static variable: shared by all books
        public static string LibraryName = "City Central Library";

        // Static method to show library name
        public static void ShowLibraryName()
        {
            Console.WriteLine("\nWelcome to " + LibraryName);
        }

        // Read-only variable: cannot be changed after creation
        public readonly string ISBN;

        // Book details
        public string Title;
        public string Author;

        // Constructor to initialize book details
        public LibrarySystem(string isbn, string title, string author)
        {
            this.ISBN = isbn;   // 'this' refers to the current object's ISBN
            this.Title = title;
            this.Author = author;
        }

        // Method to display book information
        public void ShowBookInfo()
        {
            Console.WriteLine("\nBook Details:");
            Console.WriteLine("Library: " + LibraryName);
            Console.WriteLine("Title  : " + Title);
            Console.WriteLine("Author : " + Author);
            Console.WriteLine("ISBN   : " + ISBN);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Show the library name
            LibrarySystem.ShowLibraryName();

            // Ask user how many books they want to add
            Console.Write("\nHow many books do you want to add? ");
            int numberOfBooks = int.Parse(Console.ReadLine());

            // Create an array to store book objects
            LibrarySystem[] books = new LibrarySystem[numberOfBooks];

            // Get book details from user
            for (int i = 0; i < numberOfBooks; i++)
            {
                Console.WriteLine($"\nEnter details for book {i + 1}:");

                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();

                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Author: ");
                string author = Console.ReadLine();

                // Create a new book object
                books[i] = new LibrarySystem(isbn, title, author);
            }

            // Display all book details
            Console.WriteLine("\nAll Books in Library:");

            for (int i = 0; i < numberOfBooks; i++)
            {
                // Check if object is a LibrarySystem object
                if (books[i] is LibrarySystem)
                {
                    books[i].ShowBookInfo();
                }
            }

            Console.WriteLine("\nThank you for using the Library System!");
        }
    }
}