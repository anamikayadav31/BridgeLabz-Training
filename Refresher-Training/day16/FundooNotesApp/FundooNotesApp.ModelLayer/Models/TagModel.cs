namespace FundooNotesApp.ModelLayer.Models;

// Safe, client-facing version of a tag - leaves out UserId, same
// pattern as NoteModel and UserModel.
public class TagModel
{
    public int TagId { get; set; }
    public string Name { get; set; } = "";
}
