using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.BusinessLayer.Services;

// NoteQueryBL handles every operation that only READS notes.
// Nothing in this class ever calls SaveChanges - if you find yourself
// wanting to modify a note in here, that logic belongs in
// NoteCommandBL instead. Keeping that boundary strict is the whole
// point of CQRS.
public class NoteQueryBL : INoteQueryBL
{
    private readonly INoteRL _noteRL;

    public NoteQueryBL(INoteRL noteRL)
    {
        _noteRL = noteRL;
    }

    public List<NoteModel> GetAllNotes(int ownerUserId)
    {
        var notes = _noteRL.GetAllNotesForUser(ownerUserId);

        // ADVANCED LINQ EXAMPLE: chaining two ordering rules together.
        // OrderByDescending sorts pinned notes to the top first, then
        // ThenByDescending breaks ties by showing the newest notes
        // first within each group - exactly how Google Keep behaves.
        return notes
            .OrderByDescending(n => n.IsPinned)
            .ThenByDescending(n => n.CreatedOn)
            .Select(NoteMapper.ToModel)
            .ToList();
    }

    public NoteModel GetNoteById(int noteId, int ownerUserId)
    {
        var note = _noteRL.GetNoteByIdAndOwner(noteId, ownerUserId);
        if (note == null)
        {
            throw new NoteNotFoundException("No note found with this id for your account.");
        }
        return NoteMapper.ToModel(note);
    }

    public List<NoteModel> SearchByTitle(int ownerUserId, string keyword)
    {
        return _noteRL.SearchByTitle(ownerUserId, keyword)
            .OrderByDescending(n => n.CreatedOn)
            .Select(NoteMapper.ToModel)
            .ToList();
    }

    public List<NoteModel> FilterByText(int ownerUserId, string keyword)
    {
        return _noteRL.FilterByTitleOrDescription(ownerUserId, keyword)
            .OrderByDescending(n => n.CreatedOn)
            .Select(NoteMapper.ToModel)
            .ToList();
    }

    public NotesSummaryModel GetNotesSummary(int ownerUserId)
    {
        var allNotes = _noteRL.GetAllNotesIncludingTrashed(ownerUserId);

        // ADVANCED LINQ EXAMPLE: GroupBy.
        // We group every note into one of four "buckets" based on its
        // status, then Count() how many fall into each bucket - all in
        // a single pass over the data instead of four separate loops.
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
}
