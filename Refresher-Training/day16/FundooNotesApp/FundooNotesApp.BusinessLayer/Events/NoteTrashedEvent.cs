namespace FundooNotesApp.BusinessLayer.Events;

public class NoteTrashedEvent
{
    public int NoteId { get; set; }
    public int UserId { get; set; }
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
}
