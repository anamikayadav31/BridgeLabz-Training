using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.DTOs.RequestDTO;

// Shape of the JSON the client sends to create a new note.
// Notice there's no "UserId" field here - the client can't choose
// whose note it is, we work that out from their JWT token instead.
public class CreateNoteDTO
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    [MaxLength(2000)]
    public string Content { get; set; } = "";
}
