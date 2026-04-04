using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.BookBuddy
{
    internal class BookShelfMain
    {
        static void Main()
        {
            BookShelfMenu menu = new BookShelfMenu();
            Console.WriteLine("Welcome to BookBuddy-Digital BookShelf App!");
            menu.ShelfMenu();
        }
    }
}
