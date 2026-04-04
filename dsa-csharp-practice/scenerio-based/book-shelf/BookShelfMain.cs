using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.bookShelf
{
    internal class BookShelfMain
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            int choice;

            do
            {
                Console.WriteLine("\n===== Library Menu =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Display Library");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        library.AddBook();
                        break;
                    case 2:
                        library.BorrowBook();
                        break;
                    case 3:
                        library.DisplayLibrary();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 4);
        }
    }
}

