using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.Entities;

// ENTITY = the exact shape of ONE ROW in the "Reminders" table.
//
// BEGINNER NOTE: this used to be a single "Reminder" column sitting
// directly on NoteEntity. Pulling it out into its own table is a
// small but meaningful design upgrade - a note only ever needed ONE
// reminder date before, but as a standalone table there's room to
// later support multiple reminders per note, snooze history, or
// notification status, without reshaping the Notes table at all.
public class ReminderEntity
{
    [Key]
    public int ReminderId { get; set; }

    [Required]
    public DateTime ReminderTime { get; set; }

    // Which note this reminder is attached to.
    public int NoteId { get; set; }

    // Who owns this reminder - filled in from the JWT token, same
    // pattern as every other entity's UserId in this project.
    public int UserId { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
