using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
{
    internal class AdressBookMenu
    {


        public void ShowMenu()
        {
            IAdress system = new AddressBookSystem();
            AdressBookUtility selectedBook = null;
            string choice = "";
            while (choice != "8")
            {
                Console.WriteLine("1. Add Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Add Contact");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Add Multiple Contacts");
                Console.WriteLine("7. Show Address Books");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Enter your choice");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        system.AddAddressBook();
                        break;

                    case "2":
                        selectedBook = system.SelectAddressBook();
                        break;

                    case "3":
                        if (selectedBook != null)
                            selectedBook.AddContact();
                        else
                            Console.WriteLine("Select Address Book first!");
                        break;

                    case "4":
                        if (selectedBook != null)
                            selectedBook.EditContact();
                        else
                            Console.WriteLine("Select Address Book first!");
                        break;

                    case "5":
                        if (selectedBook != null)
                            selectedBook.DeleteContact();
                        else
                            Console.WriteLine("Select Address Book first!");
                        break;

                    case "6":
                        if (selectedBook != null)
                            selectedBook.AddMultipleContact();
                        else
                            Console.WriteLine("Select Address Book first!");
                        break;
                    case "7":
                        system.DisplayAddressBooks(); 
                        break;


                    case "8":
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }




    }
}
