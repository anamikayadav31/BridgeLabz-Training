namespace FundooNotesApp.ModelLayer.Exceptions;

// Thrown when a note can't be found - either it never existed, or it
// belongs to a DIFFERENT user (we deliberately use the same message
// for both cases, so a user can't "probe" which note IDs exist by
// trying random numbers).
public class NoteNotFoundException : Exception
{
    public NoteNotFoundException(string message) : base(message) { }
}
