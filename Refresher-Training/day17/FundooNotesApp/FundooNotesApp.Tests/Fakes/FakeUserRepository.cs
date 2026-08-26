using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.Tests.Fakes;

// Same idea as FakeNoteRepository, but for users - see that file for
// the full explanation of why we use a hand-written fake here.
public class FakeUserRepository : IUserRL
{
    public List<UserEntity> Users { get; } = new();
    private int _nextId = 1;

    public UserModel Register(UserEntity user)
    {
        user.UserId = _nextId++;
        Users.Add(user);
        return new UserModel
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

    public UserEntity? GetUserByEmail(string email) =>
        Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

    public UserEntity? GetUserByResetToken(string token) =>
        Users.FirstOrDefault(u => u.ResetToken == token);

    public UserEntity UpdateUser(UserEntity user) => user;
}
