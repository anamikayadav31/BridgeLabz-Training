using Microsoft.Extensions.Logging;
using FundooNotesApp.BusinessLayer.Helpers;
using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.BusinessLayer.Services;

// UserBL is the "brain" of the User module.
// The Controller calls into these methods; these methods call the
// Repository (IUserRL) whenever they need the database, and the
// helper classes (PasswordHelper / TokenGenerator) whenever they need
// security-related work done.
public class UserBL : IUserBL
{
    private readonly IUserRL _userRL;
    private readonly TokenGenerator _tokenGenerator;
    private readonly ILogger<UserBL> _logger;

    public UserBL(IUserRL userRL, TokenGenerator tokenGenerator, ILogger<UserBL> logger)
    {
        _userRL = userRL;
        _tokenGenerator = tokenGenerator;
        _logger = logger;
    }

    public string Register(RegistrationDTO registrationDTO)
    {
        // RULE 1: one account per email address.
        var existingUser = _userRL.GetUserByEmail(registrationDTO.Email);
        if (existingUser != null)
        {
            _logger.LogWarning("Registration blocked - email {Email} already exists", registrationDTO.Email);
            throw new UserAlreadyExistsException("An account with this email already exists.");
        }

        // RULE 2: never store the raw password - hash it first.
        string hashedPassword = PasswordHelper.CreateHash(registrationDTO.Password);

        var newUser = new UserEntity
        {
            FirstName = registrationDTO.FirstName,
            LastName = registrationDTO.LastName,
            Email = registrationDTO.Email,
            PasswordHash = hashedPassword
        };

        _userRL.Register(newUser);
        _logger.LogInformation("New user registered: {Email}", newUser.Email);

        return "Registration successful.";
    }

    public string Login(LoginDTO loginDTO)
    {
        // Step 1: does this email even have an account?
        var user = _userRL.GetUserByEmail(loginDTO.Email);
        if (user == null)
        {
            throw new UserNotFoundException("No account found with this email.");
        }

        // Step 2: does the typed password match the stored hash?
        bool passwordIsCorrect = PasswordHelper.IsMatch(loginDTO.Password, user.PasswordHash);
        if (!passwordIsCorrect)
        {
            _logger.LogWarning("Failed login attempt for {Email} - wrong password", loginDTO.Email);
            throw new InvalidCredentialsException("The password you entered is incorrect.");
        }

        _logger.LogInformation("User {Email} logged in successfully", loginDTO.Email);

        // Step 3: login succeeded - hand back a signed JWT the client
        // can use to prove their identity on future requests.
        return _tokenGenerator.CreateTokenFor(user.UserId, user.Email);
    }

    public string ForgetPassword(ForgotPasswordDTO forgetPasswordDTO)
    {
        var user = _userRL.GetUserByEmail(forgetPasswordDTO.Email);
        if (user == null)
        {
            throw new UserNotFoundException("No account found with this email.");
        }

        // Generate a random, hard-to-guess token and give it a 30 minute
        // shelf life, so old reset links can't be used forever.
        string resetToken = Guid.NewGuid().ToString("N");
        user.ResetToken = resetToken;
        user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

        _userRL.UpdateUser(user);

        // In a production app, this token would be emailed to the user
        // instead of being returned directly - we return it here so it's
        // easy to test the flow end-to-end in Swagger/Postman.
        return resetToken;
    }

    public string ResetPassword(ResetPasswordDTO resetPasswordDTO)
    {
        var user = _userRL.GetUserByResetToken(resetPasswordDTO.Token);

        // The token must exist AND still be within its 30-minute window.
        bool tokenIsValid = user != null
            && user.ResetTokenExpiry != null
            && user.ResetTokenExpiry >= DateTime.UtcNow;

        if (!tokenIsValid)
        {
            throw new InvalidCredentialsException("This reset link is invalid or has expired.");
        }

        // Save the new password and clear the used-up token so it
        // can't be replayed a second time.
        user!.PasswordHash = PasswordHelper.CreateHash(resetPasswordDTO.NewPassword);
        user.ResetToken = null;
        user.ResetTokenExpiry = null;

        _userRL.UpdateUser(user);

        return "Your password has been reset successfully.";
    }
}
