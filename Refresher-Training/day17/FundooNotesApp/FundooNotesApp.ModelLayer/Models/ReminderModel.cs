namespace FundooNotesApp.ModelLayer.Models;

// Safe, client-facing version of a reminder - leaves out UserId, same
// pattern as NoteModel and TagModel.
public class ReminderModel
{
    public int ReminderId { get; set; }
    public int NoteId { get; set; }
    public DateTime ReminderTime { get; set; }
}
