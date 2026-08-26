using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.Entities;

public class NoteTagEntity
{
    [Key]
    public int NoteTagId { get; set; }
    public int NoteId { get; set; }
    public int TagId { get; set; }
}