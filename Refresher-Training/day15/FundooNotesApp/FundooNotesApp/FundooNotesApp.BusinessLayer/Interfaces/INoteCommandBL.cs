using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// BEGINNER NOTE: This is the "C" in CQRS - Command Query
// Responsibility Segregation.
//
// The idea: split every operation into two buckets -
//   COMMANDS = anything that CHANGES data (create, update, delete)
//   QUERIES  = anything that only READS data
//
// Why bother? Because writes and reads often have very different
// needs. A write needs to check rules and protect data integrity.
// A read just needs to be fast and flexible (sorting, filtering,
// searching). Keeping them in separate classes means each one stays
// focused on its own job, instead of one giant class doing everything.
//
// This interface only ever CHANGES the Notes table - nothing here
// returns a list to browse or search through, that's INoteQueryBL's job.
public interface INoteCommandBL
{
    NoteModel CreateNote(CreateNoteDTO createNoteDTO, int ownerUserId);
    NoteModel TogglePin(int noteId, int ownerUserId);
    NoteModel ToggleArchive(int noteId, int ownerUserId);
    NoteModel MoveToTrash(int noteId, int ownerUserId);
    NoteModel RestoreFromTrash(int noteId, int ownerUserId);
    void DeleteNote(int noteId, int ownerUserId);
}
