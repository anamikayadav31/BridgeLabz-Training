using FundooNotesApp.ModelLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FundooNotesApp.RepositoryLayer.Context;

// FundooContext is our "bridge" to the actual database.
// EF Core reads this class to figure out what tables should exist
// (one DbSet property = one table).
public class FundooContext : DbContext
{
    // ASP.NET Core passes in the connection-string settings here -
    // we configure those once, in Program.cs.
    public FundooContext(DbContextOptions<FundooContext> options) : base(options) { }

    // This becomes the "Users" table in SQL Server.
    public DbSet<UserEntity> Users { get; set; }

    // This becomes the "Notes" table in SQL Server.
    public DbSet<NoteEntity> Notes { get; set; }

    // This becomes the "Tags" table in SQL Server.
    public DbSet<TagEntity> Tags { get; set; }

    // The join table connecting Notes and Tags (many-to-many).
    public DbSet<NoteTagEntity> NoteTags { get; set; }

    // This becomes the "Reminders" table in SQL Server.
    public DbSet<ReminderEntity> Reminders { get; set; }
}
