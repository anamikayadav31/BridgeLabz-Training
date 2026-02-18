namespace AddressBookSystem
{
    // Interface defining all Address Book operations
    internal interface IAddressBook
    {
        // UC2 + UC7 → Add a new contact
        void AddContact();

        // UC3 → Edit an existing contact
        void EditContact();

        // UC4 → Delete a contact
        void DeleteContact();

        // UC5 → Add multiple contacts
        void AddMultipleContacts();

        // UC8 → Search contacts by city or state
        void SearchByCityOrState();

        // UC9 → View persons by city or state
        void ViewPersonsByCityOrState();

        // UC10 → Count persons by city or state
        void CountPersonsByCityOrState();

        // UC11 → Sort contacts by name
        void SortContactsByName();

        // UC12 → Sort contacts by city
        void SortContactsByCity();

        // UC12 → Sort contacts by state
        void SortContactsByState();

        // UC12 → Sort contacts by ZIP
        void SortContactsByZip();

        // UC13 → Write contacts to file
        void WriteContactsToFile();

        // UC13 → Read contacts from file
        void ReadContactsFromFile();

        // UC14 → Write contacts to CSV
        void WriteContactsToCSV();

        // UC14 → Read contacts from CSV
        void ReadContactsFromCSV();

        // UC15 → Write contacts to JSON
        void WriteContactsToJSON();

        // UC15 → Read contacts from JSON
        void ReadContactsFromJSON();
    }
}
