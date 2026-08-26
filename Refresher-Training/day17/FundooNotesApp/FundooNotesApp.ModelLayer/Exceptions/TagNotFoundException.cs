namespace FundooNotesApp.ModelLayer.Exceptions;

// Thrown when a tag doesn't exist, or exists but belongs to a
// different user - same "one shared message" idea as NoteNotFoundException.
public class TagNotFoundException : Exception
{
    public TagNotFoundException(string message) : base(message) { }
}
