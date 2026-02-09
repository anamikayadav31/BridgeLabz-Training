using System;

namespace AddressBookSystem
{
    internal class AddressBookMenu
    {
        public void ShowMenu()
        {
            AddressBookUtility currentBook = null;

            while (true)
            {
                try
                {
                    Console.WriteLine("\n===============================");
                    Console.WriteLine(" ADDRESS BOOK MENU ");
                    Console.WriteLine("===============================");
                    Console.WriteLine("1. Create Address Book");
                    Console.WriteLine("2. Select Address Book");
                    Console.WriteLine("3. Add Contact");
                    Console.WriteLine("4. Edit Contact");
                    Console.WriteLine("5. Delete Contact");
                    Console.WriteLine("6. Add Multiple Contacts");
                    Console.WriteLine("7. Search by City/State");
                    Console.WriteLine("8. View persons by City/State");
                    Console.WriteLine("9. Count persons by City/State");
                    Console.WriteLine("10. Sort contacts by Name");
                    Console.WriteLine("11. Sort contacts by City");   // UC-12
                    Console.WriteLine("12. Sort contacts by State");  // UC-12
                    Console.WriteLine("13. Sort contacts by Zip");    // UC-12
                    Console.WriteLine("14. Write contacts to File");   // UC-13
                    Console.WriteLine("15. Read contacts from File"); // UC-13
                    Console.WriteLine("16. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddressBookUtility.CreateAddressBook();
                            break;

                        case "2":
                            currentBook = AddressBookUtility.SelectAddressBook();
                            break;

                        case "3":
                            if (currentBook != null) currentBook.AddContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "4":
                            if (currentBook != null) currentBook.EditContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "5":
                            if (currentBook != null) currentBook.DeleteContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "6":
                            if (currentBook != null) currentBook.AddMultipleContacts();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "7":
                            if (currentBook != null) currentBook.SearchByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "8":
                            if (currentBook != null) currentBook.ViewPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "9":
                            if (currentBook != null) currentBook.CountPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "10":
                            if (currentBook != null) currentBook.SortContactsByName();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "11":
                            if (currentBook != null) currentBook.SortContactsByCity();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "12":
                            if (currentBook != null) currentBook.SortContactsByState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "13":
                            if (currentBook != null) currentBook.SortContactsByZip();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "14":
                            if (currentBook != null) currentBook.WriteContactsToFile();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "15":
                            if (currentBook != null) currentBook.ReadContactsFromFile();
                            else Console.WriteLine("Please select an address book first!");
                            break;


                        case "16":
                            Console.WriteLine("Exiting Address Book System...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Menu Error: " + ex.Message);
                }
            }
        }
    }
}
