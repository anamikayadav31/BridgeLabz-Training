using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.DTOs.RequestDTO;

// Shape of the JSON the client sends to create a new note.
// Notice there's no "UserId" or status flags (Pin/Archive/Trash) here -
// the client can't choose whose note it is or set its status upfront,
// those are decided by our own code.
public class CreateNoteDTO
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    [MaxLength(1000)]
    public string Description { get; set; } = "";

    // Optional - only set this if the note needs a reminder.
    public DateTime? Reminder { get; set; }

    // Optional - a hex color code like "#FFAA00", purely cosmetic.
    [MaxLength(20)]
    public string? BackgroundColor { get; set; }
}
