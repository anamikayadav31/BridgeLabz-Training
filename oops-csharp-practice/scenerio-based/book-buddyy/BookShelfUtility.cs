using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.BookBuddy
{
    internal class BookShelfUtility : IBook

    {
        private string[] bookNames;
        private string[] author;
        public void addBook()
        {

            Console.WriteLine("Enter the number of books:");
            int n = int.Parse(Console.ReadLine());
            bookNames = new string[n];
            author = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter  book title {i+1}:");
                bookNames[i] = Console.ReadLine();
                Console.WriteLine($"Enter  author name {i+1}:");
                author[i] = Console.ReadLine();
            }
        }
        public void searchBook()
        {
            Console.WriteLine("Enter author name to search:");
            string searchAuthor = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < author.Length; i++)
            {
                if (author[i] == searchAuthor)
                {
                    Console.WriteLine("Book Found!");
                    Console.WriteLine("Book Name: " + bookNames[i]);
                    Console.WriteLine("Author: " + author[i]);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No book found for this author.");
            }
        }
        // Sort books lexicographically
        public void sortBooks()
        {
            for (int i = 0; i < bookNames.Length - 1; i++)
            {
                for (int j = 0; j < bookNames.Length - 1 - i; j++)
                {
                    // Compare strings manually
                    if (string.Compare(bookNames[j], bookNames[j + 1]) > 0)
                    {
                        // Swap book names
                        string tempBook = bookNames[j];
                        bookNames[j] = bookNames[j + 1];
                        bookNames[j + 1] = tempBook;

                        // Swap corresponding authors
                        string tempAuthor = author[j];
                        author[j] = author[j + 1];
                        author[j + 1] = tempAuthor;
                    }
                }
            }

            Console.WriteLine("Books sorted in lexicographical order:");
            for (int i = 0; i < bookNames.Length; i++)
            {
                Console.WriteLine(bookNames[i] + " - " + author[i]);
            }
        }
    }
}









    
