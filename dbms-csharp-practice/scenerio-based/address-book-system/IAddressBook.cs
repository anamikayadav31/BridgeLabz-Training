namespace AddressBookSystem
{
    // Interface defining all Address Book operations
    // Each method represents a Use Case (UC)
    internal interface IAddressBook
    {
        // UC2 + UC7
        // Add a single new contact to the address book
        void AddContact();

        // UC3
        // Edit an existing contact's details
        void EditContact();

        // UC4
        // Delete a contact from the address book
        void DeleteContact();

        // UC5
        // Add multiple contacts at once
        void AddMultipleContacts();

        // UC8
        // Search contacts by city or state
        void SearchByCityOrState();

        // UC9
        // View all persons belonging to a city or state
        void ViewPersonsByCityOrState();

        // UC10
        // Count number of persons in a city or state
        void CountPersonsByCityOrState();

        // UC11
        // Sort contacts alphabetically by name
        void SortContactsByName();

        // UC12
        // Sort contacts by city
        void SortContactsByCity();

        // UC12
        // Sort contacts by state
        void SortContactsByState();

        // UC12
        // Sort contacts by ZIP code
        void SortContactsByZip();

        // UC13
        // Save contacts to a text/file storage
        void WriteContactsToFile();

        // UC13
        // Read contacts from a text/file storage
        void ReadContactsFromFile();

        // UC14
        // Export contacts to CSV format
        void WriteContactsToCSV();

        // UC14
        // Import contacts from CSV file
        void ReadContactsFromCSV();

        // UC15
        // Save contacts in JSON format
        void WriteContactsToJSON();

        // UC15
        // Load contacts from JSON format
        void ReadContactsFromJSON();
    }
}
