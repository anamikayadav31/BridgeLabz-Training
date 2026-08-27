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

    [MaxLength(1000)]
    public string Description { get; set; } = "";

    // Optional color tag for the note, e.g. "#FFAA00" - purely cosmetic.
    [MaxLength(20)]
    public string? BackgroundColor { get; set; }

    // Three independent status flags a note can carry. See NoteBL for
    // the RULES around these (e.g. Pin and Archive can't both be true).
    public bool IsPinned { get; set; } = false;
    public bool IsArchived { get; set; } = false;
    public bool IsTrashed { get; set; } = false;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    // Filled in whenever we touch the note (pin/archive/trash/restore) -
    // lets the client show "last edited 5 minutes ago" style info.
    public DateTime? LastEditedOn { get; set; }

    // This is the important bit that links a note to its owner.
    // We fill this in from the JWT token's "UserId" claim - the
    // CLIENT never gets to say whose note this is, we decide that
    // ourselves based on who is logged in.
    //
    // Note: we're keeping this as a plain int column (no navigation
    // property to UserEntity) since we never need to load "this
    // note's User object" directly - every ownership check already
    // happens by comparing UserId to the value from the JWT token.
    public int UserId { get; set; }
}
