namespace FundooNotesApp.ModelLayer.Exceptions;

// Thrown when a password doesn't match, or a reset token is wrong/expired.
// The Controller turns this into a 401 Unauthorized (login) or
// 400 Bad Request (reset password) response.
public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException(string message) : base(message) { }
}
