namespace FundooNotesApp.ModelLayer.Models;

// A clean, "safe to show the client" version of a note.
// We use this in every response instead of handing back NoteEntity
// directly - keeps the API contract stable even if the database
// shape changes later, and deliberately leaves out UserId (the
// client already knows whose notes these are).
public class NoteModel
{
    public int NoteId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime? Reminder { get; set; }
    public string? BackgroundColor { get; set; }
    public bool IsPinned { get; set; }
    public bool IsArchived { get; set; }
    public bool IsTrashed { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? LastEditedOn { get; set; }
}
