using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.adress_book
{
    internal class AddressBookMain
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBookMenu menu = new AddressBookMenu();
            menu.ShowMenu();
        }
    }
}
