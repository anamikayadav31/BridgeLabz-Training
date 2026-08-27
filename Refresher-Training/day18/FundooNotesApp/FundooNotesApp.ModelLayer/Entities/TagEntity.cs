using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.Entities;

// ENTITY = the exact shape of ONE ROW in the "Tags" table.
// A tag is just a little label like "Work" or "Urgent" that belongs
// to one user - the same tag can then be attached to many notes.
public class TagEntity
{
    [Key]
    public int TagId { get; set; }

    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = "";

    // Every tag belongs to exactly one user - same ownership idea as notes.
    public int UserId { get; set; }
}
