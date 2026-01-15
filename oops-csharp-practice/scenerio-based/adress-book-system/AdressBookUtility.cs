using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
{


    internal class AdressBookUtility : IAdress
    {//Uc2
     // Arrays to store contact details
        private string[] firstnames;   // Stores first names of contacts
        private string[] lastnames;    // Stores last names of contacts
        private string[] adress;       // Stores addresses of contacts
        private string[] state;        // Stores states of contacts
        private int[] zipcode;         // Stores zip codes of contacts
        private int[] phonenumber;     // Stores phone numbers of contacts
        private string[] email;        // Stores emails of contacts

        private int contactCount = 0;  // Keeps track of the number of contacts added
        public AdressBookUtility()
        {
            Console.WriteLine("Enter the number of contacts:");
            int numberOfContacts = int.Parse(Console.ReadLine());
            firstnames = new string[numberOfContacts];
            lastnames = new string[numberOfContacts];
            adress = new string[numberOfContacts];
            state = new string[numberOfContacts];
            zipcode = new int[numberOfContacts];
            phonenumber = new int[numberOfContacts];
            email = new string[numberOfContacts];
        }

        // Method to add a new contact
        public void AddContact()
        {
           

                // Taking input for each field of the contact
                Console.WriteLine($"Enter the firstName of person{contactCount + 1}");
                firstnames[contactCount] = Console.ReadLine();

                Console.WriteLine($"Enter the LastName of person{contactCount + 1}");
                lastnames[contactCount] = Console.ReadLine();

                Console.WriteLine($"Enter the adress of person{contactCount + 1}");
                adress[contactCount] = Console.ReadLine();

                Console.WriteLine($"Enter the state {contactCount + 1}");
                state[contactCount] = Console.ReadLine();

                Console.WriteLine($"Enter the zipcode {contactCount + 1}");
                zipcode[contactCount] = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the PhoneNumber of person{contactCount + 1}");
                phonenumber[contactCount] = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the Email of person{contactCount + 1}");
                email[contactCount] = Console.ReadLine();
            

            // Increment contact count after adding a contact
            contactCount++;
            
        }
        //UC3
        public void EditContact()
        {//ask user to enter name of person to change contact information
            Console.WriteLine("Enter the old first name:");
            string oldName = Console.ReadLine();

            bool found = false;
            //loop
            for (int i = 0; i < contactCount; i++)
            {
                if (firstnames[i].Equals(oldName))
                {
                    Console.WriteLine("Enter new first name:");
                    firstnames[i] = Console.ReadLine();

                    Console.WriteLine("Enter new last name:");
                    lastnames[i] = Console.ReadLine();

                    Console.WriteLine("Enter new address:");
                    adress[i] = Console.ReadLine();

                    Console.WriteLine("Enter new state:");
                    state[i] = Console.ReadLine();

                    Console.WriteLine("Enter new zipcode:");
                    zipcode[i] = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter new phone number:");
                    phonenumber[i] = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter new email:");
                    email[i] = Console.ReadLine();

                    found = true;
                    Console.WriteLine("Contact updated successfully!");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Contact not found!");
            }
        }

        //UC4
        public void DeleteContact()
        {
            Console.WriteLine("Enter the first name of the person to delete:");
            string nameToDelete = Console.ReadLine();

            int deleteIndex = -1;

            // Step 1: Find contact index
            for (int i = 0; i < contactCount; i++)
            {
                if (firstnames[i].Equals(nameToDelete))
                {
                    deleteIndex = i;
                    break;
                }
            }

            // Step 2: If not found
            if (deleteIndex == -1)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            // Step 3: Shift elements to left
            for (int i = deleteIndex; i < contactCount - 1; i++)
            {
                firstnames[i] = firstnames[i + 1];
                lastnames[i] = lastnames[i + 1];
                adress[i] = adress[i + 1];
                state[i] = state[i + 1];
                zipcode[i] = zipcode[i + 1];
                phonenumber[i] = phonenumber[i + 1];
                email[i] = email[i + 1];
            }

            // Step 4: Reduce count
            contactCount--;

            // Step 5: Resize arrays
            // Create new arrays with reduced size
            string[] newFirstnames = new string[contactCount];
            string[] newLastnames = new string[contactCount];
            string[] newAdress = new string[contactCount];
            string[] newState = new string[contactCount];
            int[] newZipcode = new int[contactCount];
            int[] newPhonenumber = new int[contactCount];
            string[] newEmail = new string[contactCount];

            // Copy data using for loop
            for (int i = 0; i < contactCount; i++)
            {
                newFirstnames[i] = firstnames[i];
                newLastnames[i] = lastnames[i];
                newAdress[i] = adress[i];
                newState[i] = state[i];
                newZipcode[i] = zipcode[i];
                newPhonenumber[i] = phonenumber[i];
                newEmail[i] = email[i];
            }

            // Assign new arrays back
            firstnames = newFirstnames;
            lastnames = newLastnames;
            adress = newAdress;
            state = newState;
            zipcode = newZipcode;
            phonenumber = newPhonenumber;
            email = newEmail;

            Console.WriteLine("Contact deleted successfully!");
        }

        //UC5
        public void AddMultipleContact()
        {
            string option="";
           
            do
            {
                AddContact();
                if (contactCount == firstnames.Length)
                {
                    Console.WriteLine("Adress Book is full!");
                    break;
                }
                Console.WriteLine("Do you want to add more contacts(Enter Yes/No):");
                 option = Console.ReadLine();
            }
            while (option.Equals("Yes")) ;


        }
    }
}