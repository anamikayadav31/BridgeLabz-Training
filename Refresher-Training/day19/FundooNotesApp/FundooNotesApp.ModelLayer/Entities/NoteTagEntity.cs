using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.Entities;

// BEGINNER NOTE: A single note can have MANY tags, and a single tag
// can be attached to MANY notes ("Work" might be on 10 different
// notes). Databases can't store a "list" directly inside a row, so we
// use a small "join table" like this one instead - each row here just
// means "this NoteId is linked to this TagId".
//
// [Key] is needed here because EF Core's automatic primary-key
// detection only recognizes a property named exactly "Id" or
// "<ClassName>Id" (e.g. "NoteTagEntityId" for this class) - our
// property is named "NoteTagId" instead, which doesn't match that
// pattern, so we have to point EF at it explicitly.
public class NoteTagEntity
{
    [Key]
    public int NoteTagId { get; set; }
    public int NoteId { get; set; }
    public int TagId { get; set; }
}
