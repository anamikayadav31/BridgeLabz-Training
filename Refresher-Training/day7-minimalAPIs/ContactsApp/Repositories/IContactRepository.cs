using ContactsApp.Models;

namespace ContactsApp.Repositories
{
    // Defines contact operations
    public interface IContactRepository
    {
        List<Contact> GetAll();       // Get all contacts
        Contact? GetById(int id);     // Get contact by ID
        void Add(Contact contact);    // Add contact
        void Update(Contact contact); // Update contact
        void Delete(int id);          // Delete contact
    }
}