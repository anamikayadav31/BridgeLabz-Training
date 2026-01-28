using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.adress_book
{
    internal class AddressBookSystem
    {




        private Dictionary<string, AddressBookUtility> addressBooks =
            new Dictionary<string, AddressBookUtility>();

        public void AddAddressBook()
        {
            Console.WriteLine("Enter Address Book Name:");
            string name = Console.ReadLine();

            if (addressBooks.ContainsKey(name))
            {
                Console.WriteLine("Address Book already exists!");
                return;
            }

            addressBooks[name] = new AddressBookUtility();
            Console.WriteLine("Address Book created!");
        }

        public AddressBookUtility SelectAddressBook()
        {
            Console.WriteLine("Enter Address Book Name:");
            string name = Console.ReadLine();

            if (addressBooks.ContainsKey(name))
                return addressBooks[name];

            Console.WriteLine("Address Book not found!");
            return null;
        }

        public void DisplayAddressBooks()
        {
            Console.WriteLine("Available Address Books:");
            foreach (var name in addressBooks.Keys)
                Console.WriteLine(name);
        }
    }
}