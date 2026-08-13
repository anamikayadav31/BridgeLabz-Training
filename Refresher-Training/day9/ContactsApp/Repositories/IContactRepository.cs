using ContactsApp.Models;

namespace ContactsApp.Repositories;

// This is a "contract" - it tells what methods any Contact repository
// class must have. Program.cs only talks to this interface, not the
// actual EF code, so it does not need to know HOW the data is fetched.
public interface IContactRepository
{
    List<Contact> GetAll();
    Contact? GetById(int id);
    void Add(Contact contact);
    void Update(Contact contact);
    void Delete(int id);
}
