namespace FundooNotesApp.ModelLayer.Models;

// UserModel is a "safe" copy of UserEntity - it deliberately leaves
// out PasswordHash, ResetToken, and ResetTokenExpiry, since those
// should never travel back out of the app.
//
// We use this whenever the Repository layer needs to hand a freshly
// created user back up to the Business layer, without exposing
// anything sensitive.
public class UserModel
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
}
