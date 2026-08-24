using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.Tests.Fakes;

// BEGINNER NOTE: this is a "fake" - a stand-in for the real NoteRL
// that stores notes in a plain in-memory List instead of a real SQL
// Server database. We use this in tests so:
//   1. Tests run instantly, no database needed.
//   2. Tests can't accidentally touch real data.
//   3. We're only testing NoteCommandBL/NoteQueryBL's LOGIC, not EF Core.
//
// This does the same job as a mocking library (like Moq), just
// written out by hand so there's no extra library to learn.
public class FakeNoteRepository : INoteRL
{
    public List<NoteEntity> Notes { get; } = new();
    private int _nextId = 1;

    public NoteEntity AddNote(NoteEntity note)
    {
        note.NoteId = _nextId++;
        Notes.Add(note);
        return note;
    }

    public List<NoteEntity> GetAllNotesForUser(int ownerUserId) =>
        Notes.Where(n => n.UserId == ownerUserId && !n.IsTrashed).ToList();

    public List<NoteEntity> GetAllNotesIncludingTrashed(int ownerUserId) =>
        Notes.Where(n => n.UserId == ownerUserId).ToList();

    public NoteEntity? GetNoteByIdAndOwner(int noteId, int ownerUserId) =>
        Notes.FirstOrDefault(n => n.NoteId == noteId && n.UserId == ownerUserId);

    public void DeleteNote(NoteEntity note) => Notes.Remove(note);

    public NoteEntity SetPinned(NoteEntity note, bool isPinned)
    {
        note.IsPinned = isPinned;
        return note;
    }

    public NoteEntity SetArchived(NoteEntity note, bool isArchived)
    {
        note.IsArchived = isArchived;
        return note;
    }

    public NoteEntity MoveToTrash(NoteEntity note)
    {
        note.IsTrashed = true;
        note.IsPinned = false;
        note.IsArchived = false;
        return note;
    }

    public NoteEntity RestoreFromTrash(NoteEntity note)
    {
        note.IsTrashed = false;
        return note;
    }

    public List<NoteEntity> SearchByTitle(int ownerUserId, string keyword) =>
        Notes.Where(n => n.UserId == ownerUserId && !n.IsTrashed && n.Title.Contains(keyword)).ToList();

    public List<NoteEntity> FilterByTitleOrDescription(int ownerUserId, string keyword) =>
        Notes.Where(n => n.UserId == ownerUserId && !n.IsTrashed &&
                          (n.Title.Contains(keyword) || n.Description.Contains(keyword))).ToList();
}
