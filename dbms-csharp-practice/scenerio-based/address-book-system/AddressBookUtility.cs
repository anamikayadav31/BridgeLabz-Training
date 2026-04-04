using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;
using System.Net.Http;

namespace AddressBookSystem
{
    internal class AddressBookUtility : IAddressBook
    {
        // UC-2: Using List to store contacts (dynamic size)
        private List<Contact> contacts = new List<Contact>();

        // UC-13 File path for text file storage
        private static string filePath = "AddressBook.txt";

        // UC-14 CSV file path
        private static string csvFilePath = "AddressBook.csv";

        // UC-15 JSON file path
        private static string jsonFilePath = "AddressBook.json";

        // HTTP client for JSON server communication
        private static readonly HttpClient client = new HttpClient();

        // Constructor runs when object is created
        public AddressBookUtility()
        {
            Console.WriteLine(" Address Book initialized successfully!");
        }

        // UC-6: Store multiple address books
        private static List<AddressBookUtility> addressBooks = new List<AddressBookUtility>();
        private static List<string> addressBookNames = new List<string>();

        // UC-6 Create Address Book
        public static void CreateAddressBook()
        {
            // Ask user for unique name
            Console.Write("\nEnter unique Address Book name: ");
            string name = Console.ReadLine();

            // Check duplicate name
            if (addressBookNames.Contains(name))
            {
                Console.WriteLine(" Address Book already exists!");
                return;
            }

            // Add new address book
            addressBooks.Add(new AddressBookUtility());
            addressBookNames.Add(name);

            Console.WriteLine(" Address Book created successfully!");
        }

        // UC-6 Select Address Book
        public static AddressBookUtility SelectAddressBook()
        {
            Console.Write("\nEnter Address Book name to select: ");
            string name = Console.ReadLine();

            // Search by name
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

                // Take basic details
                Console.Write("First Name : ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name  : ");
                string lastName = Console.ReadLine();

                // UC-7 Prevent duplicate contacts
                foreach (var c in contacts)
                {
                    if (c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                        c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                        throw new DuplicateContactException(" Duplicate contact not allowed!");
                }

                // Take full details
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

                // Add to list
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

                // Find matching contact
                foreach (var contact in contacts)
                {
                    if (contact.GetFullName().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        // Update fields
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

                // Search and remove
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
                AddContact(); // reuse method
                Console.Write("Do you want to add another contact? (y/n): ");
                choice = Console.ReadLine().ToLower()[0];
            } while (choice == 'y');
        }

        // UC-8 Search by city/state
        public void SearchByCityOrState()
        {
            Console.Write("\nEnter City or State to search: ");
            string input = Console.ReadLine();

            bool found = false;

            // Match city or state
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

        // UC-9 View persons (reuses search)
        public void ViewPersonsByCityOrState()
        {
            SearchByCityOrState();
        }

        // UC-10 Count persons
        public void CountPersonsByCityOrState()
        {
            Console.Write("\nEnter City or State: ");
            string input = Console.ReadLine();

            // Count matching
            int total = contacts.FindAll(c =>
                c.City.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                c.State.Equals(input, StringComparison.OrdinalIgnoreCase)).Count;

            Console.WriteLine($" Number of persons in '{input}': {total}");
        }

        // UC-11 Sort by name
        public void SortContactsByName()
        {
            contacts.Sort((a, b) => string.Compare(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by Person Name:");
            DisplayAllContacts();
        }

        // UC-12 Sort by city
        public void SortContactsByCity()
        {
            contacts.Sort((a, b) => string.Compare(a.City, b.City, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by City:");
            DisplayAllContacts();
        }

        // UC-12 Sort by state
        public void SortContactsByState()
        {
            contacts.Sort((a, b) => string.Compare(a.State, b.State, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by State:");
            DisplayAllContacts();
        }

        // UC-12 Sort by zip
        public void SortContactsByZip()
        {
            contacts.Sort((a, b) => string.Compare(a.Zip, b.Zip, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\n Contacts sorted by Zip:");
            DisplayAllContacts();
        }

        // Display all contacts
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

        // UC-13 Write to text file
        public void WriteContactsToFile()
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);

                // Write each contact as comma-separated line
                foreach (var c in contacts)
                {
                    writer.WriteLine($"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State},{c.Zip},{c.Phone},{c.Email}");
                }

                writer.Close();
                Console.WriteLine("Contacts written to file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Write Error: " + ex.Message);
            }
        }

        // UC-13 Read from text file
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

                // Convert each line to Contact object
                foreach (var line in lines)
                {
                    string[] d = line.Split(',');
                    contacts.Add(new Contact(d[0], d[1], d[2], d[3], d[4], d[5], d[6], d[7]));
                }

                Console.WriteLine("Contacts readed from file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Read Error: " + ex.Message);
            }
        }

        // UC-14 Write CSV
        public void WriteContactsToCSV()
        {
            try
            {
                StreamWriter writer = new StreamWriter(csvFilePath);

                // CSV header
                writer.WriteLine("FirstName,LastName,Address,City,State,Zip,Phone,Email");

                foreach (var c in contacts)
                {
                    writer.WriteLine($"{c.FirstName},{c.LastName},{c.Address},{c.City},{c.State},{c.Zip},{c.Phone},{c.Email}");
                }

                writer.Close();
                Console.WriteLine("Contacts written to CSV file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("CSV Write Error: " + ex.Message);
            }
        }

        // UC-14 Read CSV
        public void ReadContactsFromCSV()
        {
            try
            {
                if (!File.Exists(csvFilePath))
                {
                    Console.WriteLine("CSV file not found!");
                    return;
                }

                string[] lines = File.ReadAllLines(csvFilePath);
                contacts.Clear();

                // Skip header row
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] d = lines[i].Split(',');
                    contacts.Add(new Contact(d[0], d[1], d[2], d[3], d[4], d[5], d[6], d[7]));
                }

                Console.WriteLine("Contacts loaded from CSV successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("CSV Read Error: " + ex.Message);
            }
        }

        // UC-15 Write JSON
        public void WriteContactsToJSON()
        {
            try
            {
                string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, json);
                Console.WriteLine("Contacts written to JSON successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("JSON Write Error: " + ex.Message);
            }
        }

        // UC-15 Read JSON
        public void ReadContactsFromJSON()
        {
            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    Console.WriteLine("JSON file not found!");
                    return;
                }

                string json = File.ReadAllText(jsonFilePath);
                contacts = JsonSerializer.Deserialize<List<Contact>>(json);

                Console.WriteLine("Contacts loaded from JSON successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("JSON Read Error: " + ex.Message);
            }
        }

        // UC16 Send to JSON server
        public async Task WriteToJsonServer()
        {
            string url = "http://localhost:3000/contacts";

            foreach (var c in contacts)
            {
                string json = JsonSerializer.Serialize(c);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = await client.PostAsync(url, content);

                Console.WriteLine(res.IsSuccessStatusCode ? "Contact uploaded." : "Failed to upload contact.");
            }
        }

        // UC16 Read from server
        public async Task ReadFromJsonServer()
        {
            string url = "http://localhost:3000/contacts";

            HttpResponseMessage res = await client.GetAsync(url);

            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to fetch data from server.");
                return;
            }

            string json = await res.Content.ReadAsStringAsync();

            contacts = JsonSerializer.Deserialize<List<Contact>>(json);

            Console.WriteLine("Contacts loaded from JSON Server!");
        }

        // UC17 Async File Write
        public async Task WriteContactsToFileAsync()
        {
            await Task.Run(() => WriteContactsToFile());
            Console.WriteLine("Async File Write Completed!");
        }

        // UC17 Async File Read
        public async Task ReadContactsFromFileAsync()
        {
            await Task.Run(() => ReadContactsFromFile());
            Console.WriteLine("Async File Read Completed!");
        }

        // UC17 Async CSV Write
        public async Task WriteContactsToCSVAsync()
        {
            await Task.Run(() => WriteContactsToCSV());
            Console.WriteLine("Async CSV Write Completed!");
        }

        // UC17 Async CSV Read
        public async Task ReadContactsFromCSVAsync()
        {
            await Task.Run(() => ReadContactsFromCSV());
            Console.WriteLine("Async CSV Read Completed!");
        }

        // UC17 Async JSON Write
        public async Task WriteContactsToJSONAsync()
        {
            await Task.Run(() => WriteContactsToJSON());
            Console.WriteLine("Async JSON Write Completed!");
        }

        // UC17 Async JSON Read
        public async Task ReadContactsFromJSONAsync()
        {
            await Task.Run(() => ReadContactsFromJSON());
            Console.WriteLine("Async JSON Read Completed!");
        }

        // UC18 Save to DB
        public void SaveToDatabase()
        {
            IDataStorage db = new DatabaseStorage();
            db.Save(contacts);
            Console.WriteLine("Contacts saved to database!");
        }

        // UC18 Load from DB
        public void LoadFromDatabase()
        {
            IDataStorage db = new DatabaseStorage();
            contacts = db.Load();
            Console.WriteLine("Contacts loaded from database!");
        }
    }
}
