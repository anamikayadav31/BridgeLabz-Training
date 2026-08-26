using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.RepositoryLayer.Context;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.RepositoryLayer.Services;

// NoteRL = the REAL implementation of INoteRL.
// Same pattern as UserRL - plain database reads/writes only, no
// business decisions (like "is pinning this note even allowed right
// now?") happen here, that's NoteBL's job.
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

    public List<NoteEntity> GetAllNotesForUser(int ownerUserId)
    {
        // Trashed notes are hidden from the normal "all notes" list -
        // the client has a separate view/endpoint for the trash if needed.
        return _context.Notes
            .Where(n => n.UserId == ownerUserId && !n.IsTrashed)
            .ToList();
    }

    public List<NoteEntity> GetAllNotesIncludingTrashed(int ownerUserId)
    {
        return _context.Notes
            .Where(n => n.UserId == ownerUserId)
            .ToList();
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

    public NoteEntity SetPinned(NoteEntity note, bool isPinned)
    {
        note.IsPinned = isPinned;
        note.LastEditedOn = DateTime.UtcNow;
        _context.SaveChanges();
        return note;
    }

    public NoteEntity SetArchived(NoteEntity note, bool isArchived)
    {
        note.IsArchived = isArchived;
        note.LastEditedOn = DateTime.UtcNow;
        _context.SaveChanges();
        return note;
    }

    public NoteEntity MoveToTrash(NoteEntity note)
    {
        note.IsTrashed = true;
        // A trashed note shouldn't still show up as pinned or archived.
        note.IsPinned = false;
        note.IsArchived = false;
        note.LastEditedOn = DateTime.UtcNow;
        _context.SaveChanges();
        return note;
    }

    public NoteEntity RestoreFromTrash(NoteEntity note)
    {
        // Just clears the trash flag - it comes back as a normal note,
        // not automatically re-pinned or re-archived.
        note.IsTrashed = false;
        note.LastEditedOn = DateTime.UtcNow;
        _context.SaveChanges();
        return note;
    }

    public List<NoteEntity> SearchByTitle(int ownerUserId, string keyword)
    {
        return _context.Notes
            .Where(n => n.UserId == ownerUserId && !n.IsTrashed && n.Title.Contains(keyword))
            .ToList();
    }

    public List<NoteEntity> FilterByTitleOrDescription(int ownerUserId, string keyword)
    {
        return _context.Notes
            .Where(n => n.UserId == ownerUserId && !n.IsTrashed &&
                        (n.Title.Contains(keyword) || n.Description.Contains(keyword)))
            .ToList();
    }
}
