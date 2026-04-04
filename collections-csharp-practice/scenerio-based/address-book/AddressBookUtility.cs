using System;
using System.Collections.Generic;
using System.IO;


namespace AddressBookSystem
{
    internal class AddressBookUtility : IAddressBook
    {
        // UC-2: List instead of array
        private List<Contact> contacts = new List<Contact>();

        // UC-13 File path
    private static string filePath = "AddressBook.txt";

        // Constructor
        public AddressBookUtility()
        {
            Console.WriteLine(" Address Book initialized successfully!");
        }

        // UC-6 Storage
        private static List<AddressBookUtility> addressBooks = new List<AddressBookUtility>();
        private static List<string> addressBookNames = new List<string>();

        // UC-6 Create Address Book
        public static void CreateAddressBook()
        {
            Console.Write("\nEnter unique Address Book name: ");
            string name = Console.ReadLine();

            if (addressBookNames.Contains(name))
            {
                Console.WriteLine(" Address Book already exists!");
                return;
            }

            addressBooks.Add(new AddressBookUtility());
            addressBookNames.Add(name);

            Console.WriteLine(" Address Book created successfully!");
        }

        // UC-6 Select Address Book
        public static AddressBookUtility SelectAddressBook()
        {
            Console.Write("\nEnter Address Book name to select: ");
            string name = Console.ReadLine();

            for (int i = 0; i < addressBookNames.Count; i++)
            {
                if (addressBookNames[i].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($" Address Book '{name}' selected!");
                    return addressBooks[i];
                }
            }

            Console.WriteLine(" Address Book not found!");
            return null;
        }

        // UC-2 + UC-7 Add Contact
        public void AddContact()
        {
            try
            {
                Console.WriteLine("\n--- ADD NEW CONTACT ---");
                Console.Write("First Name : ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name  : ");
                string lastName = Console.ReadLine();

                foreach (var c in contacts)
                {
                    if (c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                        c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                        throw new DuplicateContactException(" Duplicate contact not allowed!");
                }

                Console.Write("Address    : ");
                string address = Console.ReadLine();
                Console.Write("City       : ");
                string city = Console.ReadLine();
                Console.Write("State      : ");
                string state = Console.ReadLine();
                Console.Write("Zip        : ");
                string zip = Console.ReadLine();
                Console.Write("Phone      : ");
                string phone = Console.ReadLine();
                Console.Write("Email      : ");
                string email = Console.ReadLine();

                contacts.Add(new Contact(firstName, lastName, address, city, state, zip, phone, email));

                Console.WriteLine(" Contact added successfully!");
            }
            catch (DuplicateContactException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC-3 Edit Contact
        public void EditContact()
        {
            try
            {
                Console.Write("\nEnter Full Name to edit: ");
                string name = Console.ReadLine();

                foreach (var contact in contacts)
                {
                    if (contact.GetFullName().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter new City  : ");
                        contact.City = Console.ReadLine();
                        Console.Write("Enter new State : ");
                        contact.State = Console.ReadLine();
                        Console.WriteLine(" Contact updated successfully!");
                        return;
                    }
                }

                throw new ContactNotFoundException(" Contact not found!");
            }
            catch (ContactNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC-4 Delete Contact
        public void DeleteContact()
        {
            try
            {
                Console.Write("\nEnter Full Name to delete: ");
                string name = Console.ReadLine();

                for (int i = 0; i < contacts.Count; i++)
                {
                    if (contacts[i].GetFullName().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        contacts.RemoveAt(i);
                        Console.WriteLine(" Contact deleted successfully!");
                        return;
                    }
                }

                throw new ContactNotFoundException(" Contact not found!");
            }
            catch (ContactNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC-5 Add Multiple Contacts
        public void AddMultipleContacts()
        {
            char choice;
            do
            {
                AddContact();
                Console.Write("Do you want to add another contact? (y/n): ");
                choice = Console.ReadLine().ToLower()[0];
            } while (choice == 'y');
        }

        // UC-8 Search contacts by City or State
        public void SearchByCityOrState()
        {
            Console.Write("\nEnter City or State to search: ");
            string input = Console.ReadLine();

            bool found = false;
            foreach (var c in contacts)
            {
                if (c.City.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                    c.State.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(c);
                    found = true;
                }
            }

            if (!found) Console.WriteLine(" No contacts found.");
        }

        // UC-9 View persons by City or State
        public void ViewPersonsByCityOrState()
        {
            SearchByCityOrState();
        }

        // UC-10 Count persons by City or State
        public void CountPersonsByCityOrState()
        {
            Console.Write("\nEnter City or State: ");
            string input = Console.ReadLine();

            int total = contacts.FindAll(c =>
                c.City.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                c.State.Equals(input, StringComparison.OrdinalIgnoreCase)).Count;

            Console.WriteLine($" Number of persons in '{input}': {total}");
        }

        // UC-11 Sort contacts by person name
        public void SortContactsByName()
        {
            contacts.Sort((a, b) => string.Compare(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by Person Name:");
            DisplayAllContacts();
        }

        // UC-12 Sort contacts by City
        public void SortContactsByCity()
        {
            contacts.Sort((a, b) => string.Compare(a.City, b.City, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by City:");
            DisplayAllContacts();
        }

        // UC-12 Sort contacts by State
        public void SortContactsByState()
        {
            contacts.Sort((a, b) => string.Compare(a.State, b.State, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by State:");
            DisplayAllContacts();
        }

        // UC-12 Sort contacts by Zip
        public void SortContactsByZip()
        {
            contacts.Sort((a, b) => string.Compare(a.Zip, b.Zip, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by Zip:");
            DisplayAllContacts();
        }

        private void DisplayAllContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine(" No contacts available.");
                return;
            }

            foreach (var c in contacts)
                Console.WriteLine(c);
        }

        // UC-13: Write contacts to file
public void WriteContactsToFile()
{
    try
    {
        StreamWriter writer = new StreamWriter(filePath);

        foreach (var c in contacts)
        {
            writer.WriteLine(
                c.FirstName + "," +
                c.LastName + "," +
                c.Address + "," +
                c.City + "," +
                c.State + "," +
                c.Zip + "," +
                c.Phone + "," +
                c.Email
            );
        }

        writer.Close();
        Console.WriteLine("Contacts written to file successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("File Write Error: " + ex.Message);
    }
}

// UC-13: Read contacts from file
public void ReadContactsFromFile()
{
    try
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        contacts.Clear();

        foreach (var line in lines)
        {
            string[] data = line.Split(',');

            Contact person = new Contact(
                data[0], data[1], data[2],
                data[3], data[4], data[5],
                data[6], data[7]
            );

            contacts.Add(person);
        }

        Console.WriteLine("Contacts readed from file successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("File Read Error: " + ex.Message);
    }
}

    }
}
