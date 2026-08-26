using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.DTOs.RequestDTO;

// Shape of the JSON the client sends to rename an existing tag -
// only the name can change, a tag's id and owner never move.
public class EditTagDTO
{
    [Required(ErrorMessage = "Tag name is required")]
    [MaxLength(30)]
    public string Name { get; set; } = "";
}
