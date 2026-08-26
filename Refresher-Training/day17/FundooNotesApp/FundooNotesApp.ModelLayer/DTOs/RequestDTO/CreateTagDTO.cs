using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.DTOs.RequestDTO;

// Shape of the JSON the client sends to create a new tag.
public class CreateTagDTO
{
    [Required(ErrorMessage = "Tag name is required")]
    [MaxLength(30)]
    public string Name { get; set; } = "";
}
