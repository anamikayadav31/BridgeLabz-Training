using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// "BL" = Business Layer for notes. Holds the rules: a pinned note
// can't also be archived, a trashed note can't be pinned, and a user
// can only ever touch their OWN notes.
//
// ownerUserId always comes from the caller's JWT token, never from
// the request body - that's what stops one user from managing
// another user's notes.
public interface INoteBL
{
    NoteModel CreateNote(CreateNoteDTO createNoteDTO, int ownerUserId);
    List<NoteModel> GetAllNotes(int ownerUserId);
    NoteModel GetNoteById(int noteId, int ownerUserId);
    void DeleteNote(int noteId, int ownerUserId);

    NoteModel TogglePin(int noteId, int ownerUserId);
    NoteModel ToggleArchive(int noteId, int ownerUserId);
    NoteModel MoveToTrash(int noteId, int ownerUserId);
    NoteModel RestoreFromTrash(int noteId, int ownerUserId);

    List<NoteModel> SearchByTitle(int ownerUserId, string keyword);
    List<NoteModel> FilterByText(int ownerUserId, string keyword);
    NotesSummaryModel GetNotesSummary(int ownerUserId);
}
