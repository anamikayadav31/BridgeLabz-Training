using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Services;

// A tiny shared helper so both NoteCommandBL and NoteQueryBL convert
// an Entity (DB row shape) into a Model (safe response shape) the
// exact same way, instead of copy-pasting this mapping in two files.
internal static class NoteMapper
{
    public static NoteModel ToModel(NoteEntity note)
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
