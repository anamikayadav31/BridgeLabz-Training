using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.RepositoryLayer.Interfaces;

// "RL" = Repository Layer. Every database operation the Notes module
// needs. The Business layer (NoteCommandBL and NoteQueryBL) depends on this interface, not
// the real class - keeps the plumbing swappable and easy to test.
public interface INoteRL
{
    NoteEntity AddNote(NoteEntity note);

    // Every "get" here is scoped to a single owner, so a user can
    // never even accidentally fetch someone else's notes.
    List<NoteEntity> GetAllNotesForUser(int ownerUserId);
    NoteEntity? GetNoteByIdAndOwner(int noteId, int ownerUserId);

    // Unlike GetAllNotesForUser (which hides trashed notes), this
    // returns EVERYTHING - used by the summary/dashboard query where
    // we need an accurate trashed count too.
    List<NoteEntity> GetAllNotesIncludingTrashed(int ownerUserId);

    // Permanently removes a row - only ever called on notes that are
    // already sitting in the trash (see NoteCommandBL for that rule).
    void DeleteNote(NoteEntity note);

    // These four just flip a status flag and stamp LastEditedOn -
    // the actual RULES about when they're allowed live in NoteCommandBL.
    NoteEntity SetPinned(NoteEntity note, bool isPinned);
    NoteEntity SetArchived(NoteEntity note, bool isArchived);
    NoteEntity MoveToTrash(NoteEntity note);
    NoteEntity RestoreFromTrash(NoteEntity note);

    List<NoteEntity> SearchByTitle(int ownerUserId, string keyword);
    List<NoteEntity> FilterByTitleOrDescription(int ownerUserId, string keyword);
}
