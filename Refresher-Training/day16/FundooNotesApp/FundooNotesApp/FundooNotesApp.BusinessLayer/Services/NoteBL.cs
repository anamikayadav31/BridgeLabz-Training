using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.BusinessLayer.Services;

// NoteBL is the "brain" of the Notes module - same pattern as UserBL.
// The Controller calls into these methods; these methods call the
// Repository (INoteRL) whenever the database needs to be touched, and
// enforce all the little rules that make Pin/Archive/Trash behave
// sensibly together.
public class NoteBL : INoteBL
{
    private readonly INoteRL _noteRL;

    public NoteBL(INoteRL noteRL)
    {
        _noteRL = noteRL;
    }

    public NoteModel CreateNote(CreateNoteDTO createNoteDTO, int ownerUserId)
    {
        var newNote = new NoteEntity
        {
            Title = createNoteDTO.Title,
            Description = createNoteDTO.Description,
            Reminder = createNoteDTO.Reminder,
            BackgroundColor = createNoteDTO.BackgroundColor,
            // RULE: the note always belongs to whoever is logged in -
            // this value comes from the JWT token, not the request body.
            UserId = ownerUserId
        };

        var savedNote = _noteRL.AddNote(newNote);
        return ToNoteModel(savedNote);
    }

    public List<NoteModel> GetAllNotes(int ownerUserId)
    {
        return _noteRL.GetAllNotesForUser(ownerUserId)
            // Pinned notes float to the top, newest-first within each group.
            .OrderByDescending(n => n.IsPinned)
            .ThenByDescending(n => n.CreatedOn)
            .Select(ToNoteModel)
            .ToList();
    }

    public NoteModel GetNoteById(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);
        return ToNoteModel(note);
    }

    public void DeleteNote(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);

        // RULE: we only allow a PERMANENT delete on a note that's
        // already sitting in the trash - this gives users a safety net
        // (move to trash first, then delete for good), same idea as
        // Gmail or Google Keep.
        if (!note.IsTrashed)
        {
            throw new InvalidOperationException(
                "Move this note to trash first before deleting it permanently.");
        }

        _noteRL.DeleteNote(note);
    }

    public NoteModel TogglePin(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);

        if (note.IsTrashed)
        {
            throw new InvalidOperationException("A trashed note can't be pinned - restore it first.");
        }

        // RULE: Pin and Archive are mutually exclusive - a note can't
        // be both at once. If we're about to pin it, clear Archive first.
        if (!note.IsPinned && note.IsArchived)
        {
            _noteRL.SetArchived(note, false);
        }

        var updated = _noteRL.SetPinned(note, !note.IsPinned);
        return ToNoteModel(updated);
    }

    public NoteModel ToggleArchive(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);

        if (note.IsTrashed)
        {
            throw new InvalidOperationException("A trashed note can't be archived - restore it first.");
        }

        // Same mutual-exclusion rule, mirrored the other way around.
        if (!note.IsArchived && note.IsPinned)
        {
            _noteRL.SetPinned(note, false);
        }

        var updated = _noteRL.SetArchived(note, !note.IsArchived);
        return ToNoteModel(updated);
    }

    public NoteModel MoveToTrash(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);
        var updated = _noteRL.MoveToTrash(note);
        return ToNoteModel(updated);
    }

    public NoteModel RestoreFromTrash(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);
        var updated = _noteRL.RestoreFromTrash(note);
        return ToNoteModel(updated);
    }

    public List<NoteModel> SearchByTitle(int ownerUserId, string keyword)
    {
        return _noteRL.SearchByTitle(ownerUserId, keyword)
            .OrderByDescending(n => n.CreatedOn)
            .Select(ToNoteModel)
            .ToList();
    }

    public List<NoteModel> FilterByText(int ownerUserId, string keyword)
    {
        return _noteRL.FilterByTitleOrDescription(ownerUserId, keyword)
            .OrderByDescending(n => n.CreatedOn)
            .Select(ToNoteModel)
            .ToList();
    }

    public NotesSummaryModel GetNotesSummary(int ownerUserId)
    {
        var allNotes = _noteRL.GetAllNotesIncludingTrashed(ownerUserId);

        // Groups every note into one of four "buckets" based on its
        // status, then counts how many fall into each bucket in a
        // single pass over the data.
        var grouped = allNotes
            .GroupBy(n => n.IsTrashed ? "Trashed"
                        : n.IsArchived ? "Archived"
                        : n.IsPinned ? "Pinned"
                        : "Active")
            .ToDictionary(group => group.Key, group => group.Count());

        return new NotesSummaryModel
        {
            TotalActiveNotes = grouped.GetValueOrDefault("Active", 0),
            PinnedCount = grouped.GetValueOrDefault("Pinned", 0),
            ArchivedCount = grouped.GetValueOrDefault("Archived", 0),
            TrashedCount = grouped.GetValueOrDefault("Trashed", 0)
        };
    }

    // ---------- small private helpers used by several methods above ----------

    // Looks a note up AND confirms it belongs to this user in one go.
    // Using ONE shared message for "doesn't exist" and "not yours"
    // stops a user from probing which note ids belong to someone else.
    private NoteEntity FindOwnedNoteOrThrow(int noteId, int ownerUserId)
    {
        var note = _noteRL.GetNoteByIdAndOwner(noteId, ownerUserId);
        if (note == null)
        {
            throw new NoteNotFoundException("No note found with this id for your account.");
        }
        return note;
    }

    // Converts an Entity (DB row shape) into a Model (safe response shape).
    private static NoteModel ToNoteModel(NoteEntity note)
    {
        return new NoteModel
        {
            NoteId = note.NoteId,
            Title = note.Title,
            Description = note.Description,
            Reminder = note.Reminder,
            BackgroundColor = note.BackgroundColor,
            IsPinned = note.IsPinned,
            IsArchived = note.IsArchived,
            IsTrashed = note.IsTrashed,
            CreatedOn = note.CreatedOn,
            LastEditedOn = note.LastEditedOn
        };
    }
}
