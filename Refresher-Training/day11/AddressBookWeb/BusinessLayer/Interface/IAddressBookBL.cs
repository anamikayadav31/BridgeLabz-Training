using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        // Get all contacts
        List<AddressBookEntity> GetAll();

        // Get one contact by ID
        AddressBookEntity? GetById(int id);

        // Add a new contact
        AddressBookEntity Add(AddressBookDTO dto);

        // Update an existing contact
        AddressBookEntity? Update(int id, AddressBookDTO dto);

        // Delete a contact by ID
        bool Delete(int id);
    }
}