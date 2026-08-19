namespace FundooNotesApp.ModelLayer.Exceptions;

// Thrown from the Business layer when someone tries to register with
// an email that's already taken. The Controller catches this and turns
// it into a proper 409 Conflict response.
public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string message) : base(message) { }
}
