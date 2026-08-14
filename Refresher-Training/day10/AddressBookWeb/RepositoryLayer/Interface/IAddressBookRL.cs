using ModelLayer.Entities;

namespace RepositoryLayer.Interface
{
    // Defines database operations for AddressBook
    public interface IAddressBookRL
    {
        // Get all contacts
        List<AddressBookEntity> GetAll();

        // Get one contact by ID
        AddressBookEntity? GetById(int id);

        // Add a new contact
        AddressBookEntity Add(AddressBookEntity entity);

        // Update an existing contact
        AddressBookEntity? Update(int id, AddressBookEntity entity);

        // Delete a contact by ID
        bool Delete(int id);
    }
}