namespace FundooNotesApp.ModelLayer.Exceptions;

// Thrown when a reminder doesn't exist, or exists but belongs to a
// different user - same "one shared message" idea as our other
// NotFound exceptions, so a user can't probe for ids that aren't theirs.
public class ReminderNotFoundException : Exception
{
    public ReminderNotFoundException(string message) : base(message) { }
}
