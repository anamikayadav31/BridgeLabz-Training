using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Data;

// This class is the "bridge" between our C# code and the database.
// Entity Framework (EF) uses this class to know:
//   1. Which tables exist (the DbSet below)
//   2. How to connect to the database (set up in Program.cs)
// We no longer need to write raw SQL - EF builds the SQL for us.
public class ContactsDbContext : DbContext
{
    // This constructor just passes the options (like the connection string)
    // up to the base DbContext class. We don't need to change this.
    public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
    {
    }

    // This tells EF: "there is a table called Contacts, and each row
    // maps to a Contact object". EF creates/uses this table for us.
    public DbSet<Contact> Contacts { get; set; }
}
