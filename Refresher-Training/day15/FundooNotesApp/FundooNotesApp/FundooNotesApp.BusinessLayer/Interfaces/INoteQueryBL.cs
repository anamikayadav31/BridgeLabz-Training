using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// BEGINNER NOTE: This is the "Q" in CQRS.
// Every method here only READS data - nothing in this interface is
// allowed to change a single row in the database. That separation is
// the whole point of CQRS: commands and queries never mix.
public interface INoteQueryBL
{
    List<NoteModel> GetAllNotes(int ownerUserId);
    NoteModel GetNoteById(int noteId, int ownerUserId);
    List<NoteModel> SearchByTitle(int ownerUserId, string keyword);
    List<NoteModel> FilterByText(int ownerUserId, string keyword);

    // A small "dashboard" style query - counts how many notes fall
    // into each status bucket. This is the advanced-LINQ example
    // (uses GroupBy) mentioned in the Day 15 plan.
    NotesSummaryModel GetNotesSummary(int ownerUserId);
}
