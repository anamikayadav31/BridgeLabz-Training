using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.RepositoryLayer.Interfaces;

// "RL" = Repository Layer. Every database operation the Notes module
// needs. The Business layer (NoteBL) depends on this interface, not
// the real class.
public interface INoteRL
{
    // Saves a brand-new note row.
    NoteEntity AddNote(NoteEntity note);

    // Finds one note by its id AND its owner - so a user can never
    // even accidentally fetch someone else's note.
    NoteEntity? GetNoteByIdAndOwner(int noteId, int ownerUserId);

    // Removes a note row from the database.
    void DeleteNote(NoteEntity note);
}
