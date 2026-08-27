using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.DTOs.RequestDTO;

// Shape of the JSON the client sends to set a reminder on a note.
public class CreateReminderDTO
{
    [Required(ErrorMessage = "NoteId is required")]
    public int NoteId { get; set; }

    [Required(ErrorMessage = "ReminderTime is required")]
    public DateTime ReminderTime { get; set; }
}
