namespace FundooNotesApp.ModelLayer.Models;

// A clean, "safe to show the client" version of a note.
// We use this in responses instead of handing back NoteEntity directly -
// keeps the API contract stable even if the database shape changes later.
public class NoteModel
{
    public int NoteId { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}
