using ContactsApp.Data;
using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Repositories;

// This class talks to the database using Entity Framework (EF Core).
// Instead of writing raw SQL like before (SqlConnection, SqlCommand),
// we now just use the DbContext and plain C# / LINQ. EF converts our
// C# code into SQL behind the scenes.
public class ContactRepository : IContactRepository
{
    private readonly ContactsDbContext dbContext;

    public ContactRepository(ContactsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    // Get every contact from the Contacts table
    public List<Contact> GetAll()
    {
        // ToList() runs the query and brings back all rows as a List<Contact>
        return dbContext.Contacts.ToList();
    }

    // Get a single contact by its Id. Returns null if not found.
    public Contact? GetById(int id)
    {
        // Find() looks the row up by its primary key (Id)
        return dbContext.Contacts.Find(id);
    }

    // Insert a new contact into the table
    public void Add(Contact contact)
    {
        dbContext.Contacts.Add(contact);
        // Nothing actually happens in the database until SaveChanges() is called
        dbContext.SaveChanges();
    }

    // Update an existing contact
    public void Update(Contact contact)
    {
        dbContext.Contacts.Update(contact);
        dbContext.SaveChanges();
    }

    // Delete a contact by Id
    public void Delete(int id)
    {
        Contact? contact = dbContext.Contacts.Find(id);

        if (contact != null)
        {
            dbContext.Contacts.Remove(contact);
            dbContext.SaveChanges();
        }
    }
}
