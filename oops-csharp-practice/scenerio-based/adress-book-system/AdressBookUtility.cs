/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
{




    // ================= Address Book System =================
    //UC6
    internal class AddressBookSystem : IAdress
    {
        private string[] addressBookNames;
        private AdressBookUtility[] addressBooks;
        private int bookCount = 0;

        public AddressBookSystem()
        {
            Console.WriteLine("Enter number of Address Books:");
            int size = int.Parse(Console.ReadLine());

            addressBookNames = new string[size];
            addressBooks = new AdressBookUtility[size];
        }

       
        public void AddAddressBook()
        {
            if (bookCount == addressBooks.Length)
            {
                Console.WriteLine("Address Book limit reached!");
                return;
            }

            Console.WriteLine("Enter Address Book Name:");
            string name = Console.ReadLine();

            for (int i = 0; i < bookCount; i++)
            {
                if (addressBookNames[i].Equals(name))
                {
                    Console.WriteLine("Address Book already exists!");
                    return;
                }
            }

            addressBookNames[bookCount] = name;
            addressBooks[bookCount] = new AdressBookUtility();
            bookCount++;

            Console.WriteLine("Address Book created successfully!");
        }

        public AdressBookUtility SelectAddressBook()
        {
            Console.WriteLine("Enter Address Book Name to select:");
            string name = Console.ReadLine();

            for (int i = 0; i < bookCount; i++)
            {
                if (addressBookNames[i].Equals(name))
                {
                    return addressBooks[i];
                }
            }

            Console.WriteLine("Address Book not found!");
            return null;
        }

        public void DisplayAddressBooks()
        {
            if (bookCount == 0)
            {
                Console.WriteLine("No Address Books available.");
                return;
            }

            Console.WriteLine("Available Address Books:");
            for (int i = 0; i < bookCount; i++)
            {
                Console.WriteLine(addressBookNames[i]);
            }
        }

        // Contact methods are not applicable for system-level class
        public void AddContact() => Console.WriteLine("AddContact() not applicable for Address Book System.");
        public void EditContact() => Console.WriteLine("EditContact() not applicable for Address Book System.");
        public void DeleteContact() => Console.WriteLine("DeleteContact() not applicable for Address Book System.");
        public void AddMultipleContact() => Console.WriteLine("AddMultipleContact() not applicable for Address Book System.");
    }

    // ================= Address Book Utility =================
    //UC1
    internal class AdressBookUtility : IAdress
    {
        private string[] firstnames;
        private string[] lastnames;
        private string[] address;
        private string[] state;
        private int[] zipcode;
        private string[] phonenumber;
        private string[] email;
        private int contactCount = 0;

        public AdressBookUtility()
        {
            Console.WriteLine("Enter the number of contacts for this Address Book:");
            int numberOfContacts = int.Parse(Console.ReadLine());

            firstnames = new string[numberOfContacts];
            lastnames = new string[numberOfContacts];
            address = new string[numberOfContacts];
            state = new string[numberOfContacts];
            zipcode = new int[numberOfContacts];
            phonenumber = new string[numberOfContacts];
            email = new string[numberOfContacts];
        }
        //UC2
        // Contact methods
        public void AddContact()

        {
            Console.WriteLine($"Enter first name for person {contactCount + 1}:");
            string fname = Console.ReadLine();

            // UC7 – Duplicate check using array
            for (int i = 0; i < contactCount; i++)
            {
                if (firstnames[i].Equals(fname, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Duplicate entry! Person already exists.");
                    return;
                }
            }

            firstnames[contactCount] = fname;

            if (contactCount == firstnames.Length)
            {
                Console.WriteLine("Address Book is full!");
                return;
            }

            Console.WriteLine($"Enter first name for person {contactCount + 1}:");
            firstnames[contactCount] = Console.ReadLine();

            Console.WriteLine($"Enter last name for person {contactCount + 1}:");
            lastnames[contactCount] = Console.ReadLine();

            Console.WriteLine($"Enter address for person {contactCount + 1}:");
            address[contactCount] = Console.ReadLine();

            Console.WriteLine($"Enter state for person {contactCount + 1}:");
            state[contactCount] = Console.ReadLine();

            Console.WriteLine($"Enter zipcode for person {contactCount + 1}:");
            zipcode[contactCount] = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter phone number for person {contactCount + 1}:");
            phonenumber[contactCount] = Console.ReadLine();

            Console.WriteLine($"Enter email for person {contactCount + 1}:");
            email[contactCount] = Console.ReadLine();

            contactCount++;
            Console.WriteLine("Contact added successfully!");
        }//UC3

        public void EditContact()
        {
            Console.WriteLine("Enter first name of the person to edit:");
            string oldName = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < contactCount; i++)
            {
                if (firstnames[i].Equals(oldName))
                {
                    Console.WriteLine("Enter new first name:");
                    firstnames[i] = Console.ReadLine();

                    Console.WriteLine("Enter new last name:");
                    lastnames[i] = Console.ReadLine();

                    Console.WriteLine("Enter new address:");
                    address[i] = Console.ReadLine();

                    Console.WriteLine("Enter new state:");
                    state[i] = Console.ReadLine();

                    Console.WriteLine("Enter new zipcode:");
                    zipcode[i] = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter new phone number:");
                    phonenumber[i] = Console.ReadLine();

                    Console.WriteLine("Enter new email:");
                    email[i] = Console.ReadLine();

                    found = true;
                    Console.WriteLine("Contact updated successfully!");
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Contact not found!");
        }
        //UC4
        public void DeleteContact()
        {
            Console.WriteLine("Enter first name of the person to delete:");
            string nameToDelete = Console.ReadLine();
            int deleteIndex = -1;

            for (int i = 0; i < contactCount; i++)
            {
                if (firstnames[i].Equals(nameToDelete))
                {
                    deleteIndex = i;
                    break;
                }
            }

            if (deleteIndex == -1)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            for (int i = deleteIndex; i < contactCount - 1; i++)
            {
                firstnames[i] = firstnames[i + 1];
                lastnames[i] = lastnames[i + 1];
                address[i] = address[i + 1];
                state[i] = state[i + 1];
                zipcode[i] = zipcode[i + 1];
                phonenumber[i] = phonenumber[i + 1];
                email[i] = email[i + 1];
            }

            contactCount--;
            Console.WriteLine("Contact deleted successfully!");
        }

        public void AddMultipleContact()
        {
            string option;
            do
            {
                AddContact();
                if (contactCount == firstnames.Length)
                {
                    Console.WriteLine("Address Book is full!");
                    break;
                }
                Console.WriteLine("Do you want to add more contacts (Yes/No)?");
                option = Console.ReadLine();
            } while (option.Equals("Yes"));
        }

        public void SearchByCityOrState()
        {
            Console.WriteLine("Enter the city or State name:");
            string value = Console.ReadLine();
            for (int i = 0; i < contactCount; i++)
            {
                if (address[i].Equals(value) ||
                    state[i].Equals(value))
                {
                    Console.WriteLine($"{firstnames[i]} {lastnames[i]} - {address[i]}, {state[i]}");
                }
            }
        }

        //UC9
        public void ViewPersonsByCity()
        {
            Console.WriteLine("Enter the city name:");
            string city = Console.ReadLine();
            Console.WriteLine($"Persons in city: {city}");
            for (int i = 0; i < contactCount; i++)
            {
                if (address[i].Equals(city))
                {
                    Console.WriteLine(firstnames[i] + " " + lastnames[i]);
                }
            }
        }
       
        //UC10
        public void CountByCity()
        {
            Console.WriteLine("Enter the city name:");
            string city = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < contactCount; i++)
            {
                if (address[i].Equals(city))
                    count++;
            }
            Console.WriteLine($"Total persons in {city}: {count}");
        }
        //UC11
        public void SortContactsByName()
        {
            for (int i = 0; i < contactCount - 1; i++)
            {
                for (int j = i + 1; j < contactCount; j++)
                {
                    if (string.Compare(firstnames[i], firstnames[j], true) > 0)
                    {
                        // swap firstnames
                        string tempFirst = firstnames[i];
                        firstnames[i] = firstnames[j];
                        firstnames[j] = tempFirst;

                        // swap lastnames
                        string tempLast = lastnames[i];
                        lastnames[i] = lastnames[j];
                        lastnames[j] = tempLast;

                        // swap address
                        string tempAddress = address[i];
                        address[i] = address[j];
                        address[j] = tempAddress;

                        // swap state
                        string tempState = state[i];
                        state[i] = state[j];
                        state[j] = tempState;

                        // swap zipcode
                        int tempZip = zipcode[i];
                        zipcode[i] = zipcode[j];
                        zipcode[j] = tempZip;

                        // swap phone
                        string tempPhone = phonenumber[i];
                        phonenumber[i] = phonenumber[j];
                        phonenumber[j] = tempPhone;

                        // swap email
                        string tempEmail = email[i];
                        email[i] = email[j];
                        email[j] = tempEmail;
                    }
                }
            }

            Console.WriteLine("Contacts sorted alphabetically by first name.");
        }




        // System-level methods not applicable for single address book
        public void AddAddressBook() => Console.WriteLine("AddAddressBook() not applicable for single Address Book.");
        public AdressBookUtility SelectAddressBook() { Console.WriteLine("SelectAddressBook() not applicable for single Address Book."); return null; }
        public void DisplayAddressBooks() => Console.WriteLine("DisplayAddressBooks() not applicable for single Address Book.");
    }


}
*/