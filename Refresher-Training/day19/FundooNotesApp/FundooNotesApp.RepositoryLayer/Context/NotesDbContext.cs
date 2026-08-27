using FundooNotesApp.ModelLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FundooNotesApp.RepositoryLayer.Context;

// The Notes Service's own database - covers Notes, Tags, the
// Note-Tag join table, and Reminders. Notice it has NO DbSet<UserEntity>
// at all - if this service needs to know "who owns this note", it
// only ever stores the UserId as a plain number (see NoteEntity.UserId),
// never a real link to a User row, because that row doesn't even
// live in this database.
public class NotesDbContext : DbContext
{
    public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

    public DbSet<NoteEntity> Notes { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<NoteTagEntity> NoteTags { get; set; }
    public DbSet<ReminderEntity> Reminders { get; set; }
}
