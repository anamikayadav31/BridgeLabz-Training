using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;

namespace RepositoryLayer.Context
{
    // Connects the application with the database
    public class AddressBookDbContext : DbContext
    {
        // Constructor
        public AddressBookDbContext(
            DbContextOptions<AddressBookDbContext> options)
            : base(options)
        {
        }

        // Represents the AddressBooks table
        public DbSet<AddressBookEntity> AddressBooks { get; set; }
    }
}