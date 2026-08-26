using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.RepositoryLayer.Interfaces;

// "RL" = Repository Layer. This is the contract for every database
// operation the User module needs. The Business layer (UserBL) depends
// on THIS interface, not the real class - which keeps it easy to test
// and easy to swap the database technology later if we ever need to.
public interface IUserRL
{
    // Saves a new user row and returns a safe (no-password) copy of it.
    UserModel Register(UserEntity user);

    // Looks a user up by email - used for login and duplicate checks.
    UserEntity? GetUserByEmail(string email);

    // Looks a user up by their password-reset token.
    UserEntity? GetUserByResetToken(string token);

    // Saves changes made to an existing user (e.g. new password, new reset token).
    UserEntity UpdateUser(UserEntity user);
}
