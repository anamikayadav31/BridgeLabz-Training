namespace FundooNotesApp.ModelLayer.Models;

// A tiny "dashboard" shape - just counts, nothing else. Used by the
// GET /api/notes/summary endpoint so a client can show something like
// "You have 12 notes, 3 pinned, 2 archived" without fetching every note.
public class NotesSummaryModel
{
    public int TotalActiveNotes { get; set; }
    public int PinnedCount { get; set; }
    public int ArchivedCount { get; set; }
    public int TrashedCount { get; set; }
}
