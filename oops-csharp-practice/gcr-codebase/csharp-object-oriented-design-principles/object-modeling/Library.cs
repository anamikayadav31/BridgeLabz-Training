using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class Library
    {


        // Book class
        public class Book
        {
            // Book details
            public string bookTitle;
            public string bookAuthor;

            // Constructor
            public Book(string bookTitle, string bookAuthor)
            {
                this.bookTitle = bookTitle;
                this.bookAuthor = bookAuthor;
            }

            // Display book details
            public void ShowBook()
            {
                Console.WriteLine("Book Title : " + bookTitle);
                Console.WriteLine("Author     : " + bookAuthor);
            }
        }

        // Library details
        public string libraryTitle;
        public List<Book> bookList;

        // Constructor
        public Library(string libraryTitle)
        {
            this.libraryTitle = libraryTitle;
            bookList = new List<Book>();
        }

        // Add book to library (Aggregation)
        public void AddBook(Book bookObj)
        {
            bookList.Add(bookObj);
        }

        // Display library details
        public void ShowLibrary()
        {
            Console.WriteLine("\nLibrary Name: " + libraryTitle);
            Console.WriteLine("Books in Library:");

            for (int i = 0; i < bookList.Count; i++)
            {
                bookList[i].ShowBook();
                Console.WriteLine();
            }
        }

        // Main method
        public static void Main(string[] args)
        {
            // Take number of libraries
            Console.WriteLine("Enter Number of Libraries:");
            int libraryCount = int.Parse(Console.ReadLine());

            Library[] libraryArray = new Library[libraryCount];

            // Create libraries
            for (int i = 0; i < libraryCount; i++)
            {
                Console.WriteLine("\nEnter Library Name:");
                string inputLibraryName = Console.ReadLine();

                libraryArray[i] = new Library(inputLibraryName);
            }

            // Take number of books
            Console.WriteLine("\nEnter Number of Books:");
            int bookCount = int.Parse(Console.ReadLine());

            Book[] bookArray = new Book[bookCount];

            // Create books
            for (int i = 0; i < bookCount; i++)
            {
                Console.WriteLine("\nEnter Book Title:");
                string inputBookTitle = Console.ReadLine();

                Console.WriteLine("Enter Book Author:");
                string inputBookAuthor = Console.ReadLine();

                bookArray[i] = new Book(inputBookTitle, inputBookAuthor);
            }

            // Add books to libraries
            for (int i = 0; i < libraryArray.Length; i++)
            {
                Console.WriteLine("\nHow many books to add to " + libraryArray[i].libraryTitle + "?");
                int addCount = int.Parse(Console.ReadLine());

                for (int j = 0; j < addCount; j++)
                {
                    Console.WriteLine("Enter Book Number (1 to " + bookCount + "):");
                    int bookIndex = int.Parse(Console.ReadLine()) - 1;

                    libraryArray[i].AddBook(bookArray[bookIndex]);
                }
            }

            // Display all libraries
            for (int i = 0; i < libraryArray.Length; i++)
            {
                libraryArray[i].ShowLibrary();
            }
        }
    }
}
