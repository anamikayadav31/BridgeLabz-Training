using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.Entities;

// ENTITY = the exact shape of ONE ROW in the "Reminders" table.

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
