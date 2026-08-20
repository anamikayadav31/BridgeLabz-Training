using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.RepositoryLayer.Context;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.RepositoryLayer.Services;

// NoteRL = the REAL implementation of INoteRL.
// Same pattern as UserRL - plain database operations only, no
// business decisions (like "is this really your note?") happen here.
public class NoteRL : INoteRL
{
    private readonly FundooContext _context;

    public NoteRL(FundooContext context)
    {
        _context = context;
    }

    public NoteEntity AddNote(NoteEntity note)
    {
        _context.Notes.Add(note);
        _context.SaveChanges();
        return note;
    }

    public NoteEntity? GetNoteByIdAndOwner(int noteId, int ownerUserId)
    {
        // Notice BOTH conditions in the WHERE clause: matching the id
        // is not enough by itself, it must also belong to this user.
        return _context.Notes
            .FirstOrDefault(n => n.NoteId == noteId && n.UserId == ownerUserId);
    }

    public void DeleteNote(NoteEntity note)
    {
        _context.Notes.Remove(note);
        _context.SaveChanges();
    }
}
