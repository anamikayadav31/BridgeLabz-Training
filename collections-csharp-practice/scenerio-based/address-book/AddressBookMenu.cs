using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.adress_book
{


    internal class AddressBookMenu
    {
        private AddressBookSystem system = new AddressBookSystem();
        private AddressBookUtility selectedBook = null;

        public void ShowMenu()
        {
            string choice = "";

            while (choice != "12")
            {
                Console.WriteLine("\n------ ADDRESS BOOK MENU ------");
                Console.WriteLine("1. Add Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Add Contact");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. View Persons By City");
                Console.WriteLine("7. Count Contacts By City");
                Console.WriteLine("8. Sort Contacts By Name");
                Console.WriteLine("9. Show Address Books");
                Console.WriteLine("12. Exit");
                Console.Write("Enter choice: ");

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
                        CheckSelected();
                        selectedBook?.AddContact();
                        break;

                    case "4":
                        CheckSelected();
                        selectedBook?.EditContact();
                        break;

                    case "5":
                        CheckSelected();
                        selectedBook?.DeleteContact();
                        break;

                    case "6":
                        CheckSelected();
                        selectedBook?.ViewPersonsByCity();
                        break;

                    case "7":
                        CheckSelected();
                        selectedBook?.CountByCity();
                        break;

                    case "8":
                        CheckSelected();
                        selectedBook?.SortContactsByName();
                        break;

                    case "9":
                        system.DisplayAddressBooks();
                        break;

                    case "12":
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void CheckSelected()
        {
            if (selectedBook == null)
                Console.WriteLine("⚠ Please select an Address Book first!");
        }
    }

}
