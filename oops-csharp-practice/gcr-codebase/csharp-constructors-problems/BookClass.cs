using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class BookClass
    {
        static void Main(string[] args)
        {
            // Using default constructor
            Book book1 = new Book();
            Console.WriteLine("Default Book:");
            Console.WriteLine("Title: " + book1.Title);
            Console.WriteLine("Author: " + book1.Author);
            Console.WriteLine("Price: " + book1.Price);
            Console.WriteLine();

            // Taking user input for parameterized constructor
            Console.WriteLine("Enter details for a new book:");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Book book2 = new Book(title, author, price);

            Console.WriteLine("\nBook Details:");
            Console.WriteLine("Title: " + book2.Title);
            Console.WriteLine("Author: " + book2.Author);
            Console.WriteLine("Price: " + book2.Price);

            
        }
    }


    class Book
    {
        public string Title;
        public string Author;
        public double Price;

        // Default constructor
        public Book()
        {
            Title = "Unknown";
            Author = "Unknown";
            Price = 0.0;
        }

        // Parameterized constructor
        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
    }
}

    
