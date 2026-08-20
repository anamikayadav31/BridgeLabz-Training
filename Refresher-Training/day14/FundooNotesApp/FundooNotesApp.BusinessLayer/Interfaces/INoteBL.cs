using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// "BL" = Business Layer for notes. Holds the rule that really matters
// here: a user can only ever create, see, or delete THEIR OWN notes.
public interface INoteBL
{
    // ownerUserId always comes from the caller's JWT token, never
    // from the request body - that's what stops one user from
    // creating or deleting notes "as" someone else.
    NoteModel CreateNote(CreateNoteDTO createNoteDTO, int ownerUserId);
    string DeleteNote(int noteId, int ownerUserId);
}
