using FundooNotesApp.BusinessLayer.Helpers;
using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.ModelLayer.Models;
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
    private readonly IEmailQueuePublisher _emailQueuePublisher;
    private readonly IResetTokenCache _resetTokenCache;

    public UserBL(IUserRL userRL, TokenGenerator tokenGenerator, IEmailQueuePublisher emailQueuePublisher, IResetTokenCache resetTokenCache)
    {
        _userRL = userRL;
        _tokenGenerator = tokenGenerator;
        _emailQueuePublisher = emailQueuePublisher;
        _resetTokenCache = resetTokenCache;
    }

    public string Register(RegistrationDTO registrationDTO)
    {
        // RULE 1: one account per email address.
        var existingUser = _userRL.GetUserByEmail(registrationDTO.Email);
        if (existingUser != null)
        {
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
            throw new InvalidCredentialsException("The password you entered is incorrect.");
        }

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
        // shelf life. This now lives in Redis instead of the Users
        // table - Redis handles the expiry for us automatically, so
        // there's no ResetTokenExpiry column to check by hand anymore.
        string resetToken = Guid.NewGuid().ToString("N");
        _resetTokenCache.StoreResetToken(resetToken, user.Email, TimeSpan.FromMinutes(30));

        // Instead of emailing the user directly (which would be a slow,
        // blocking SMTP call right here in the middle of an HTTP
        // request), we drop the email onto a RabbitMQ queue and move
        // on. EmailQueueConsumer (running separately) picks it up and
        // actually sends it.
        _emailQueuePublisher.Publish(new EmailQueueMessage
        {
            ToEmail = user.Email,
            Subject = "Reset your Fundoo Notes password",
            Body = $"Your password reset token is: {resetToken}\n\nThis token expires in 30 minutes."
        });

        return "A password reset link has been sent to your email.";
    }

    public string ResetPassword(ResetPasswordDTO resetPasswordDTO)
    {
        // Ask Redis "who was this token issued to, if it's still valid?"
        // A null here covers both cases at once: the token never
        // existed, or it did but its 30-minute TTL already ran out.
        string? email = _resetTokenCache.GetEmailForResetToken(resetPasswordDTO.Token);
        if (email == null)
        {
            throw new InvalidCredentialsException("This reset link is invalid or has expired.");
        }

        var user = _userRL.GetUserByEmail(email);
        if (user == null)
        {
            throw new UserNotFoundException("No account found with this email.");
        }

        // Save the new password and remove the used-up token from
        // Redis so it can't be replayed a second time.
        user.PasswordHash = PasswordHelper.CreateHash(resetPasswordDTO.NewPassword);
        _userRL.UpdateUser(user);
        _resetTokenCache.RemoveResetToken(resetPasswordDTO.Token);

        return "Your password has been reset successfully.";
    }
}
