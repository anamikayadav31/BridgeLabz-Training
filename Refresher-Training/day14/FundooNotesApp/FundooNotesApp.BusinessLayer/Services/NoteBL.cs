using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.BusinessLayer.Services;

// NoteBL is the "brain" of the Notes module - same pattern as UserBL.
// The Controller calls into these methods; these methods call the
// Repository (INoteRL) whenever the database needs to be touched.
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
            Content = createNoteDTO.Content,
            // RULE: the note always belongs to whoever is logged in -
            // this value comes from the JWT token, not from the
            // request body, so nobody can create a note "for" another user.
            UserId = ownerUserId
        };

        var savedNote = _noteRL.AddNote(newNote);

        // Convert the Entity into a safe Model before handing it back -
        // we don't need to expose UserId again, the client already knows who they are.
        return new NoteModel
        {
            NoteId = savedNote.NoteId,
            Title = savedNote.Title,
            Content = savedNote.Content,
            CreatedAt = savedNote.CreatedAt
        };
    }

    public string DeleteNote(int noteId, int ownerUserId)
    {
        // RULE: you can only delete a note that is BOTH the right id
        // AND actually belongs to you.
        var note = _noteRL.GetNoteByIdAndOwner(noteId, ownerUserId);
        if (note == null)
        {
            // Same message whether the note doesn't exist or belongs
            // to someone else - this stops users from "probing" for
            // valid note ids that aren't theirs.
            throw new NoteNotFoundException("No note found with this id for your account.");
        }

        _noteRL.DeleteNote(note);
        return "Note deleted successfully.";
    }
}
