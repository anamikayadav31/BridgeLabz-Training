using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundooNotesApp.BusinessLayer.Helpers;
using FundooNotesApp.BusinessLayer.Services;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Tests.Fakes;

namespace FundooNotesApp.Tests.BusinessLayerTests;

[TestClass]
public class UserBLTests
{
    private static (UserBL userBL, FakeUserRepository repo) CreateSystemUnderTest()
    {
        var repo = new FakeUserRepository();

        // A real TokenGenerator is fine to use here (not a fake) - it
        // doesn't touch a database or the network, it just does math
        // with a secret string, so it's fast and safe inside a test.
        var tokenGenerator = new TokenGenerator("test-secret-key-at-least-32-characters-long");

        // NullLogger.Instance is a built-in "do nothing" logger -
        // perfect for tests, where we don't care about log output.
        var userBL = new UserBL(repo, tokenGenerator, NullLogger<UserBL>.Instance);

        return (userBL, repo);
    }

    [TestMethod]
    public void Register_ShouldThrow_WhenEmailAlreadyExists()
    {
        var (userBL, repo) = CreateSystemUnderTest();
        repo.Users.Add(new UserEntity { Email = "test@example.com" });

        var dto = new RegistrationDTO
        {
            FirstName = "Test",
            Email = "test@example.com",
            Password = "Whatever123"
        };

        Assert.ThrowsException<UserAlreadyExistsException>(() => userBL.Register(dto));
    }

    [TestMethod]
    public void Register_ShouldNeverStoreThePlainPassword()
    {
        // This is the important security check - the "PasswordHash"
        // field should NEVER equal the raw password the user typed.
        var (userBL, repo) = CreateSystemUnderTest();
        var dto = new RegistrationDTO
        {
            FirstName = "Test",
            Email = "new@example.com",
            Password = "MySecret123"
        };

        userBL.Register(dto);

        var savedUser = repo.Users.Single();
        Assert.AreNotEqual("MySecret123", savedUser.PasswordHash);
        // BCrypt hashes always start with "$2" - a quick sanity check
        // that hashing actually happened.
        Assert.IsTrue(savedUser.PasswordHash.StartsWith("$2"));
    }

    [TestMethod]
    public void Login_ShouldThrow_WhenNoAccountExistsForThatEmail()
    {
        var (userBL, _) = CreateSystemUnderTest();
        var dto = new LoginDTO { Email = "ghost@example.com", Password = "whatever" };

        Assert.ThrowsException<UserNotFoundException>(() => userBL.Login(dto));
    }

    [TestMethod]
    public void Login_ShouldThrow_WhenPasswordIsWrong()
    {
        var (userBL, repo) = CreateSystemUnderTest();
        repo.Users.Add(new UserEntity
        {
            Email = "test@example.com",
            PasswordHash = PasswordHelper.CreateHash("CorrectPassword1")
        });

        var dto = new LoginDTO { Email = "test@example.com", Password = "WrongPassword" };

        Assert.ThrowsException<InvalidCredentialsException>(() => userBL.Login(dto));
    }

    [TestMethod]
    public void Login_ShouldReturnAToken_WhenCredentialsAreCorrect()
    {
        var (userBL, repo) = CreateSystemUnderTest();
        repo.Users.Add(new UserEntity
        {
            UserId = 1,
            Email = "test@example.com",
            PasswordHash = PasswordHelper.CreateHash("CorrectPassword1")
        });

        var dto = new LoginDTO { Email = "test@example.com", Password = "CorrectPassword1" };
        string token = userBL.Login(dto);

        // A real JWT always has exactly 3 dot-separated parts:
        // header.payload.signature - a lightweight way to sanity-check
        // we got a real token back, without decoding it fully.
        Assert.AreEqual(3, token.Split('.').Length);
    }
}
