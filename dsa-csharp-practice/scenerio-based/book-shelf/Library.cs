using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.bookShelf
{
       internal class Library : IBookShelf
        {
            private CustomHashMap catalog = new CustomHashMap();

            public void AddBook()
            {
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine();

                Console.Write("Enter book title: ");
                string title = Console.ReadLine();

                Console.Write("Enter author name: ");
                string author = Console.ReadLine();

                Book book = new Book(title, author);

                HashNode genreNode = catalog.Get(genre);
                if (genreNode == null)
                    genreNode = catalog.Put(genre);

                if (!genreNode.Value.Add(book))
                    Console.WriteLine(" Duplicate book not allowed.");
                else
                    Console.WriteLine(" Book added successfully.");
            }

            public void BorrowBook()
            {
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine();

                Console.Write("Enter book title: ");
                string title = Console.ReadLine();

                Console.Write("Enter author name: ");
                string author = Console.ReadLine();

                Book book = new Book(title, author);

                HashNode genreNode = catalog.Get(genre);

                if (genreNode == null || !genreNode.Value.Remove(book))
                    Console.WriteLine(" Book not found.");
                else
                    Console.WriteLine("Book borrowed successfully.");
            }

            public void DisplayLibrary()
            {
                catalog.Display();
            }
        }
    }


