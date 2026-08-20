using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.Entities;

// ENTITY = the exact shape of ONE ROW in the "Notes" table.
// Just like UserEntity, this class is only used inside the app
// (Business + Repository layer) - never sent straight to the client.
public class NoteEntity
{
    [Key]
    public int NoteId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = "";

    [MaxLength(2000)]
    public string Content { get; set; } = "";

    // This is the important bit that links a note to its owner.
    // We fill this in from the JWT token's "UserId" claim - the
    // CLIENT never gets to say whose note this is, we decide that
    // ourselves based on who is logged in.
    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
