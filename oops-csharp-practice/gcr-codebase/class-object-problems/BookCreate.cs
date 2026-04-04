/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.classAndObject
{
    internal class BookCreate
    {
        static void Main()
        {
            // Take book details from the user
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author Name: ");
            string author = Console.ReadLine();

            Console.Write("Enter Book Price: ");
            double price = double.Parse(Console.ReadLine());
            //create object
            Book book = new Book(title, author, price);
            Console.WriteLine("Title: " + book.Title);
            Console.WriteLine("Author: " + book.Author);
            Console.WriteLine("Price: Rs" + book.Price);
        }
    }
    class Book
    {
        public string Title;
        public string Author;
        public double Price;

        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }



    }
}

    
*/