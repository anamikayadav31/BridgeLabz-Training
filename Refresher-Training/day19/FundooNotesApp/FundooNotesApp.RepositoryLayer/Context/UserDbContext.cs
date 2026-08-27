using FundooNotesApp.ModelLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FundooNotesApp.RepositoryLayer.Context;

// BEGINNER NOTE ON MICROSERVICES: this used to be one big
// "FundooContext" shared by everything. As we split the app into
// separate services (User Management vs Notes/Tags/Reminders), each
// service needs to own ITS OWN database - that's one of the core
// rules of microservices architecture: no service should reach
// directly into another service's tables.
//
// UserDbContext only knows about the Users table - the
// User Service is the only thing allowed to touch it.
public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; }
}
