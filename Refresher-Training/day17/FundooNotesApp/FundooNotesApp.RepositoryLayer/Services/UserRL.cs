using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Context;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.RepositoryLayer.Services;

// UserRL is the REAL implementation of IUserRL.
// This class - and only this class - is allowed to talk to
// FundooContext directly. No business rules live here, just plain
// "save this" / "fetch that" database operations.
public class UserRL : IUserRL
{
    private readonly FundooContext _context;

    // ASP.NET Core injects the DbContext automatically for us.
    public UserRL(FundooContext context)
    {
        _context = context;
    }

    public UserModel Register(UserEntity user)
    {
        // Step 1: queue up the new row.
        _context.Users.Add(user);

        // Step 2: actually write it to the database.
        _context.SaveChanges();

        // Step 3: hand back a SAFE version (no password fields) so the
        // Business layer never has to worry about leaking sensitive data.
        return new UserModel
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

    public UserEntity? GetUserByEmail(string email)
    {
        // ToLower() on both sides so "Test@Mail.com" and "test@mail.com"
        // are treated as the same account.
        return _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
    }

    public UserEntity? GetUserByResetToken(string token)
    {
        return _context.Users.FirstOrDefault(u => u.ResetToken == token);
    }

    public UserEntity UpdateUser(UserEntity user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return user;
    }
}
