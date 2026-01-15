using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
{
    internal class AddressBookMain
    {
        

       static void Main()
        {
            AdressBookMenu menu = new AdressBookMenu();
            Console.WriteLine("Welcome to Address Book!");
            menu.ShowMenu();
        }
    }
}
