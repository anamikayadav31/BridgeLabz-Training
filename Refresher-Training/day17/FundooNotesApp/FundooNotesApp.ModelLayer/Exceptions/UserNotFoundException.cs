namespace FundooNotesApp.ModelLayer.Exceptions;

// Thrown when we look up a user (by email or reset token) and find
// nothing. The Controller turns this into a 404 Not Found response.
public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message) { }
}
