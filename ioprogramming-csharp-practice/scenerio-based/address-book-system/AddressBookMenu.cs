using System;

namespace AddressBookSystem
{
    internal class AddressBookMenu
    {
        // Method to display menu and handle user operations
        public async Task ShowMenu()
        {
            // Stores the currently selected address book
            AddressBookUtility currentBook = null;

            // Loop runs continuously until user exits
            while (true)
            {
                try
                {
                    // Display menu header
                    Console.WriteLine("\n===============================");
                    Console.WriteLine(" ADDRESS BOOK MENU ");
                    Console.WriteLine("===============================");

                    // Menu options
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
                    Console.WriteLine("16. Write contacts to CSV");   //UC-14
                    Console.WriteLine("17. Read contacts from CSV");  //UC-14
                    Console.WriteLine("18. Save contacts as JSON");    //UC-15
                    Console.WriteLine("19. Load contacts from JSON");  //UC-15
                    Console.WriteLine("20. Write contacts to JSON Server");  // UC-16
                    Console.WriteLine("21. Read contacts from JSON Server");  // UC-16
                    Console.WriteLine("22. Async Write to File");
                    Console.WriteLine("23. Async Read from File");
                    Console.WriteLine("24. Async Write to CSV");
                    Console.WriteLine("25. Async Read from CSV");
                    Console.WriteLine("26. Async Write to JSON");
                    Console.WriteLine("27. Async Read from JSON");
                    Console.WriteLine("28. Exit");

                    // Ask user to enter choice
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    // Perform action based on user input
                    switch (choice)
                    {
                        case "1":
                            // Create a new address book
                            AddressBookUtility.CreateAddressBook();
                            break;

                        case "2":
                            // Select an existing address book
                            currentBook = AddressBookUtility.SelectAddressBook();
                            break;

                        case "3":
                            // Add a contact if book selected
                            if (currentBook != null) currentBook.AddContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "4":
                            // Edit contact details
                            if (currentBook != null) currentBook.EditContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "5":
                            // Delete a contact
                            if (currentBook != null) currentBook.DeleteContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "6":
                            // Add multiple contacts
                            if (currentBook != null) currentBook.AddMultipleContacts();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "7":
                            // Search contacts by city/state
                            if (currentBook != null) currentBook.SearchByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "8":
                            // View persons grouped by city/state
                            if (currentBook != null) currentBook.ViewPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "9":
                            // Count persons by location
                            if (currentBook != null) currentBook.CountPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "10":
                            // Sort contacts by name
                            if (currentBook != null) currentBook.SortContactsByName();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "11":
                            // Sort contacts by city
                            if (currentBook != null) currentBook.SortContactsByCity();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "12":
                            // Sort contacts by state
                            if (currentBook != null) currentBook.SortContactsByState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "13":
                            // Sort contacts by ZIP code
                            if (currentBook != null) currentBook.SortContactsByZip();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "14":
                            // Save contacts to text file
                            if (currentBook != null) currentBook.WriteContactsToFile();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "15":
                            // Load contacts from text file
                            if (currentBook != null) currentBook.ReadContactsFromFile();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "16":
                            // Write contacts to CSV
                            if (currentBook != null) currentBook.WriteContactsToCSV();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "17":
                            // Read contacts from CSV
                            if (currentBook != null) currentBook.ReadContactsFromCSV();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "18":
                            // Save contacts as JSON
                            if (currentBook != null) currentBook.WriteContactsToJSON();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "19":
                            // Load contacts from JSON
                            if (currentBook != null) currentBook.ReadContactsFromJSON();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "20":
                            // Send contacts to JSON server
                            if (currentBook != null)
                                await currentBook.WriteToJsonServer();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "21":
                            // Fetch contacts from JSON server
                            if (currentBook != null)
                                await currentBook.ReadFromJsonServer();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "22":
                            // Async file write
                            if (currentBook != null)
                                await currentBook.WriteContactsToFileAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "23":
                            // Async file read
                            if (currentBook != null)
                                await currentBook.ReadContactsFromFileAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "24":
                            // Async CSV write
                            if (currentBook != null)
                                await currentBook.WriteContactsToCSVAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "25":
                            // Async CSV read
                            if (currentBook != null)
                                await currentBook.ReadContactsFromCSVAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "26":
                            // Async JSON write
                            if (currentBook != null)
                                await currentBook.WriteContactsToJSONAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "27":
                            // Async JSON read
                            if (currentBook != null)
                                await currentBook.ReadContactsFromJSONAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "28":
                            // Exit the program
                            Console.WriteLine("Exiting Address Book System...");
                            return;

                        default:
                            // Handle invalid input
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Show any runtime errors
                    Console.WriteLine("Menu Error: " + ex.Message);
                }
            }
        }
    }
}
