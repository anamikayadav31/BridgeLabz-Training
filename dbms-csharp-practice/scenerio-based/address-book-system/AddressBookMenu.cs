using System;

namespace AddressBookSystem
{
    internal class AddressBookMenu
    {
        // This method shows the menu and handles user choices
        // async is used because some operations (file/server) are asynchronous
        public async Task ShowMenu()
        {
            // Stores the currently selected address book
            // Starts as null until user selects/creates one
            AddressBookUtility currentBook = null;

            // Infinite loop so menu keeps running until Exit is chosen
            while (true)
            {
                try
                {
                    // ===== DISPLAY MENU UI =====
                    Console.WriteLine("\n===============================");
                    Console.WriteLine(" ADDRESS BOOK MENU ");
                    Console.WriteLine("===============================");

                    // Show all available options to user
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
                    Console.WriteLine("11. Sort contacts by City");
                    Console.WriteLine("12. Sort contacts by State");
                    Console.WriteLine("13. Sort contacts by Zip");
                    Console.WriteLine("14. Write contacts to File");
                    Console.WriteLine("15. Read contacts from File");
                    Console.WriteLine("16. Write contacts to CSV");
                    Console.WriteLine("17. Read contacts from CSV");
                    Console.WriteLine("18. Save contacts as JSON");
                    Console.WriteLine("19. Load contacts from JSON");
                    Console.WriteLine("20. Write contacts to JSON Server");
                    Console.WriteLine("21. Read contacts from JSON Server");
                    Console.WriteLine("22. Async Write to File");
                    Console.WriteLine("23. Async Read from File");
                    Console.WriteLine("24. Async Write to CSV");
                    Console.WriteLine("25. Async Read from CSV");
                    Console.WriteLine("26. Async Write to JSON");
                    Console.WriteLine("27. Async Read from JSON");
                    Console.WriteLine("28. Save to Database");
                    Console.WriteLine("29. Load from Database");
                    Console.WriteLine("30. Exit");

                    // Ask user to enter a choice
                    Console.Write("Enter your choice: ");
                    
                    // Read user input as string
                    string choice = Console.ReadLine();

                    // Switch checks which option user selected
                    switch (choice)
                    {
                        // ===== ADDRESS BOOK CREATION/SELECTION =====
                        case "1":
                            // Create a new address book
                            AddressBookUtility.CreateAddressBook();
                            break;

                        case "2":
                            // Select an existing address book
                            currentBook = AddressBookUtility.SelectAddressBook();
                            break;

                        // ===== CONTACT OPERATIONS =====
                        case "3":
                            // Add contact only if book selected
                            if (currentBook != null) currentBook.AddContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "4":
                            // Edit existing contact
                            if (currentBook != null) currentBook.EditContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "5":
                            // Delete a contact
                            if (currentBook != null) currentBook.DeleteContact();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "6":
                            // Add multiple contacts at once
                            if (currentBook != null) currentBook.AddMultipleContacts();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        // ===== SEARCH & VIEW =====
                        case "7":
                            // Search by city or state
                            if (currentBook != null) currentBook.SearchByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "8":
                            // View persons grouped by city/state
                            if (currentBook != null) currentBook.ViewPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "9":
                            // Count contacts in a city/state
                            if (currentBook != null) currentBook.CountPersonsByCityOrState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        // ===== SORTING =====
                        case "10":
                            // Sort alphabetically by name
                            if (currentBook != null) currentBook.SortContactsByName();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "11":
                            // Sort by city
                            if (currentBook != null) currentBook.SortContactsByCity();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "12":
                            // Sort by state
                            if (currentBook != null) currentBook.SortContactsByState();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "13":
                            // Sort by zip code
                            if (currentBook != null) currentBook.SortContactsByZip();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        // ===== FILE OPERATIONS =====
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

                        // ===== CSV =====
                        case "16":
                            if (currentBook != null) currentBook.WriteContactsToCSV();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "17":
                            if (currentBook != null) currentBook.ReadContactsFromCSV();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        // ===== JSON =====
                        case "18":
                            if (currentBook != null) currentBook.WriteContactsToJSON();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "19":
                            if (currentBook != null) currentBook.ReadContactsFromJSON();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        // ===== JSON SERVER (ASYNC) =====
                        case "20":
                            if (currentBook != null)
                                await currentBook.WriteToJsonServer();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        case "21":
                            if (currentBook != null)
                                await currentBook.ReadFromJsonServer();
                            else Console.WriteLine("Please select an address book first!");
                            break;

                        // ===== ASYNC FILE/CSV/JSON =====
                        case "22":
                            if (currentBook != null)
                                await currentBook.WriteContactsToFileAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "23":
                            if (currentBook != null)
                                await currentBook.ReadContactsFromFileAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "24":
                            if (currentBook != null)
                                await currentBook.WriteContactsToCSVAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "25":
                            if (currentBook != null)
                                await currentBook.ReadContactsFromCSVAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "26":
                            if (currentBook != null)
                                await currentBook.WriteContactsToJSONAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        case "27":
                            if (currentBook != null)
                                await currentBook.ReadContactsFromJSONAsync();
                            else Console.WriteLine("Select address book first!");
                            break;

                        // ===== DATABASE =====
                        case "28":
                            // Save contacts to database
                            currentBook.SaveToDatabase();
                            break;

                        case "29":
                            // Load contacts from database
                            currentBook.LoadFromDatabase();
                            break;

                        // ===== EXIT =====
                        case "30":
                            // End program
                            Console.WriteLine("Exiting Address Book System...");
                            return;

                        default:
                            // If input doesn't match any option
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Catch any unexpected runtime errors
                    Console.WriteLine("Menu Error: " + ex.Message);
                }
            }
        }
    }
}
