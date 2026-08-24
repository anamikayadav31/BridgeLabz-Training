using FundooNotesApp.BusinessLayer.Events;
using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.BusinessLayer.Services;

// NoteCommandBL handles every operation that CHANGES a note.
// All the "business rules" about what's allowed to happen live here -
// e.g. a trashed note can't be pinned, Pin and Archive can't both be
// true at once, and permanent delete only works from the trash.
public class NoteCommandBL : INoteCommandBL
{
    private readonly INoteRL _noteRL;
    private readonly INoteEventPublisher _eventPublisher;

    public NoteCommandBL(INoteRL noteRL, INoteEventPublisher eventPublisher)
    {
        _noteRL = noteRL;
        _eventPublisher = eventPublisher;
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

        // Announce that this happened - we don't know or care who (if
        // anyone) is listening. See NoteEventPublisher for why.
        _eventPublisher.PublishNoteCreated(new NoteCreatedEvent
        {
            NoteId = savedNote.NoteId,
            Title = savedNote.Title,
            UserId = ownerUserId
        });

        return NoteMapper.ToModel(savedNote);
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
        return NoteMapper.ToModel(updated);
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
        return NoteMapper.ToModel(updated);
    }

    public NoteModel MoveToTrash(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);
        var updated = _noteRL.MoveToTrash(note);

        _eventPublisher.PublishNoteTrashed(new NoteTrashedEvent
        {
            NoteId = updated.NoteId,
            UserId = ownerUserId
        });

        return NoteMapper.ToModel(updated);
    }

    public NoteModel RestoreFromTrash(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);
        var updated = _noteRL.RestoreFromTrash(note);
        return NoteMapper.ToModel(updated);
    }

    public void DeleteNote(int noteId, int ownerUserId)
    {
        var note = FindOwnedNoteOrThrow(noteId, ownerUserId);

        // RULE: we only allow a PERMANENT delete on a note that's
        // already sitting in the trash - a safety net, same idea as
        // Gmail or Google Keep (trash first, delete for good second).
        if (!note.IsTrashed)
        {
            throw new InvalidOperationException(
                "Move this note to trash first before deleting it permanently.");
        }

        _noteRL.DeleteNote(note);
    }

    // Looks a note up AND confirms it belongs to this user in one go.
    // Same message for "doesn't exist" and "not yours" so a user can't
    // probe which note ids belong to someone else.
    private NoteEntity FindOwnedNoteOrThrow(int noteId, int ownerUserId)
    {
        var note = _noteRL.GetNoteByIdAndOwner(noteId, ownerUserId);
        if (note == null)
        {
            throw new NoteNotFoundException("No note found with this id for your account.");
        }
        return note;
    }
}
