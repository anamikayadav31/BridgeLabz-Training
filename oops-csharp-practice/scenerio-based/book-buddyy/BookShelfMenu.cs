using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.BookBuddy
{
    internal class BookShelfMenu
    {
        public  void ShelfMenu()
        {
            BookShelfUtility utility = new BookShelfUtility();
            string choice = "";
            while (choice != "4")
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("Enter 1:Add books");
                Console.WriteLine("Enter 2:Search books");
                Console.WriteLine("Enter 3:Sort books");
                Console.WriteLine("Enter 4:Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        utility.addBook();
                        break;
                    case "2":
                        utility.searchBook();
                        break;
                    case "3":
                        utility.sortBooks();
                        break;
                    case "4":
                       break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

    }
}
