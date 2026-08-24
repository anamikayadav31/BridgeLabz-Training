namespace FundooNotesApp.BusinessLayer.Events;

// BEGINNER NOTE ON PUB-SUB: this class just carries information about
// something that already happened - "a note was created". It doesn't
// DO anything by itself.
public class NoteCreatedEvent
{
    public int NoteId { get; set; }
    public string Title { get; set; } = "";
    public int UserId { get; set; }
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
}
