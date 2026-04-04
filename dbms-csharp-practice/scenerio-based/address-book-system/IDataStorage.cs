using System.Collections.Generic;

namespace AddressBookSystem
{
    // Interface for handling data storage operations
    // This allows different storage types (DB, file, JSON, etc.)
    internal interface IDataStorage
    {
        // Save a list of contacts to storage
        // (could be database, file, or cloud)
        void Save(List<Contact> contacts);

        // Load and return all contacts from storage
        List<Contact> Load();
    }
}
