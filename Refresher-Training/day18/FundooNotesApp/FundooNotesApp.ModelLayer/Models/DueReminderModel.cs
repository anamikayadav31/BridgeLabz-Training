namespace FundooNotesApp.ModelLayer.Models;

// BEGINNER NOTE: the background scanner needs a few fields that live
// on THREE different tables (Reminders, Notes, Users) at once - the
// reminder time, the note's title/description, and the owner's
// email. Rather than have the scanner reach into all three tables
// itself (which would leak database concerns into the API project),
// ReminderRL does that joining and hands back this one flat,
// ready-to-email shape instead.
public class DueReminderModel
{
    public int ReminderId { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public string NoteTitle { get; set; } = string.Empty;
    public string NoteDescription { get; set; } = string.Empty;
}
