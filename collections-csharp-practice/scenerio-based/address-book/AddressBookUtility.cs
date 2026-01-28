using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BridgeLabzTraining.Collections.scnerio_based.adress_book
{
    internal class AddressBookUtility
    {






        private List<Contact> contacts = new List<Contact>();

        public void AddContact()
        {
            Console.WriteLine("Enter First Name:");
            string fname = Console.ReadLine();

            if (contacts.Any(c => c.FirstName.Equals(fname, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Duplicate contact!");
                return;
            }

            Contact contact = new Contact();
            contact.FirstName = fname;

            Console.WriteLine("Enter Last Name:");
            contact.LastName = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            contact.Address = Console.ReadLine();

            Console.WriteLine("Enter City:");
            contact.City = Console.ReadLine();

            Console.WriteLine("Enter State:");
            contact.State = Console.ReadLine();

            Console.WriteLine("Enter Zip:");
            contact.Zip = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            contact.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            contact.Email = Console.ReadLine();

            contacts.Add(contact);
            Console.WriteLine("Contact added successfully!");
        }

        public void EditContact()
        {
            Console.WriteLine("Enter First Name to edit:");
            string name = Console.ReadLine();

            Contact contact = contacts.FirstOrDefault(c =>
                c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            Console.WriteLine("Enter New City:");
            contact.City = Console.ReadLine();

            Console.WriteLine("Enter New State:");
            contact.State = Console.ReadLine();

            Console.WriteLine("Contact updated successfully!");
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter First Name to delete:");
            string name = Console.ReadLine();

            Contact contact = contacts.FirstOrDefault(c =>
                c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            contacts.Remove(contact);
            Console.WriteLine("Contact deleted!");
        }

        public void ViewPersonsByCity()
        {
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();

            var result = contacts.Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));

            foreach (var c in result)
                Console.WriteLine(c);

            if (!result.Any())
                Console.WriteLine("No contacts found!");
        }

        public void CountByCity()
        {
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();

            int count = contacts.Count(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Total contacts in {city}: {count}");
        }

        public void SortContactsByName()
        {
            contacts = contacts.OrderBy(c => c.FirstName).ToList();
            Console.WriteLine("Contacts sorted by first name!");
        }
    }
}
