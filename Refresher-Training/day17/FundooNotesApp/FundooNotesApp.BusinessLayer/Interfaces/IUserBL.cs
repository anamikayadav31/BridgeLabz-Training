using FundooNotesApp.ModelLayer.DTOs.RequestDTO;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// "BL" = Business Layer. This is where our business RULES live -
// things like "an email can only register once", "passwords must be
// hashed", "a reset link expires after 30 minutes", etc.
//
// The Controller depends on this interface, not the real class, so it
// never needs to know HOW registration/login actually work internally.
public interface IUserBL
{
    string Register(RegistrationDTO registrationDTO);
    string Login(LoginDTO loginDTO);
    string ForgetPassword(ForgotPasswordDTO forgetPasswordDTO);
    string ResetPassword(ResetPasswordDTO resetPasswordDTO);
}
