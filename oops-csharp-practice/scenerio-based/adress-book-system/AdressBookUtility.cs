using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
{


    internal class AdressBookUtility
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

        // Method to add a new contact
        public void AddContact()
        {
            // Initializing all arrays with size 0
            // NOTE: This means no contacts can actually be added, we need to resize later
            firstnames = new string[0];
            lastnames = new string[0];
            adress = new string[0];
            state = new string[0];
            zipcode = new int[0];
            phonenumber = new int[0];
            email = new string[0];

            // Loop through each contact slot (currently 0 length, so this won't run)
            for (int i = 0; i < firstnames.Length; i++)
            {
                // Taking input for each field of the contact
                Console.WriteLine($"Enter the firstName of person{i + 1}");
                firstnames[i] = Console.ReadLine();

                Console.WriteLine($"Enter the LastName of person{i + 1}");
                lastnames[i] = Console.ReadLine();

                Console.WriteLine($"Enter the adress of person{i + 1}");
                adress[i] = Console.ReadLine();

                Console.WriteLine($"Enter the state {i + 1}");
                state[i] = Console.ReadLine();

                Console.WriteLine($"Enter the zipcode {i + 1}");
                zipcode[i] = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the PhoneNumber of person{i + 1}");
                phonenumber[i] = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the Email of person{i + 1}");
                email[i] = Console.ReadLine();
            }

            // Increment contact count after adding a contact
            contactCount++;
        }
    }
}