using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class LibrarySystem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Library Book System ===");
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            Console.Write("Enter book price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            LibraryBook userBook = new LibraryBook(title, author, price);

            // Borrow the book
            Console.WriteLine("\nAttempting to borrow the book...");
            userBook.BorrowBook();

            // Try borrowing again to show unavailable message
            Console.WriteLine("Trying to borrow again...");
            userBook.BorrowBook();

        }
    }

    class LibraryBook
    {
        public string Title;
        public string Author;
        public double Price;
        public bool IsAvailable;

        // Constructor
        public LibraryBook(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
            IsAvailable = true;
        }

        // Method to borrow a book
        public void BorrowBook()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"You have successfully borrowed '{Title}'.");
            }
            else
            {
                Console.WriteLine($"Sorry, '{Title}' is currently unavailable.");
            }
        }
    }
}
    

  
