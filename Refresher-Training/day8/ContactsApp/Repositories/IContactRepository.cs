using ContactsApp.Models;

namespace ContactsApp.Repositories;

// This is just a "contract" - it tells what methods any Contact repository
// class must have. I made this so that the Program.cs file does not need
// to know HOW the data is fetched, just that these methods exist.
public interface IContactRepository
{
    List<Contact> GetAll();
    Contact? GetById(int id);
    void Add(Contact contact);
    void Update(Contact contact);
    void Delete(int id);
}
