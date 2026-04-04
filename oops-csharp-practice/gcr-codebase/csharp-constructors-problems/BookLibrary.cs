using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class BookLibrary
    {


        // Base class
        internal class Book
        {
            public string ISBN;       // public
            protected string Title;   // protected
            private string Author;    // private

            // Constructor
            public Book(string isbn, string title, string author)
            {
                ISBN = isbn;
                Title = title;
                Author = author;
            }

            // Methods to access/modify private Author
            public void SetAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public string GetAuthor()
            {
                return Author;
            }

            // Display book details
            public void ShowDetails()
            {
                Console.WriteLine("\n--- Book Details ---");
                Console.WriteLine("ISBN: " + ISBN);
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + GetAuthor());
            }
        }

        // Derived class
        internal class EBook : Book
        {
            public EBook(string isbn, string title, string author)
                : base(isbn, title, author)
            {
            }

            public static void Main(string[] args)
            {
                // User input
                Console.Write("Enter ISBN: ");
                string isbn = Console.ReadLine();

                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                // Create EBook object
                EBook ebook = new EBook(isbn, title, author);

                // Display book details
                ebook.ShowDetails();

                // Update author
                Console.Write("\nEnter new Author name to update: ");
                string newAuthor = Console.ReadLine();
                ebook.SetAuthor(newAuthor);

                Console.WriteLine("Updated Author: " + ebook.GetAuthor());
            }
        }
    }


}
