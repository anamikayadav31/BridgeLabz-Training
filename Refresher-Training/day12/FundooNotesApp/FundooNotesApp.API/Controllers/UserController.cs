using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.DTOs.ResponseDTO;
using FundooNotesApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.API.Controllers;

// Every action here starts with: /api/user/...
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    // The Controller only knows about IUserBL - it has zero idea how
    // registration/login/password-reset actually work under the hood.
    // That logic is the Business layer's job.
    private readonly IUserBL _userBL;

    public UserController(IUserBL userBL)
    {
        _userBL = userBL;
    }

    // POST /api/user/register
    // Creates a brand-new account.
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegistrationDTO registrationDTO)
    {
        try
        {
            string message = _userBL.Register(registrationDTO);
            return Ok(new ResponseDTO<string> { Success = true, Message = message });
        }
        catch (UserAlreadyExistsException ex)
        {
            // 409 Conflict - the resource (this email) already exists.
            return Conflict(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // POST /api/user/login
    // Verifies credentials and hands back a JWT access token.
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {
        try
        {
            string token = _userBL.Login(loginDTO);
            return Ok(new ResponseDTO<string>
            {
                Success = true,
                Message = "Login successful.",
                Data = token
            });
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (InvalidCredentialsException ex)
        {
            // 401 Unauthorized - wrong password.
            return Unauthorized(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // POST /api/user/forget-password
    // Generates a reset token for the given email.
    [HttpPost("forget-password")]
    public IActionResult ForgetPassword([FromBody] ForgotPasswordDTO forgetPasswordDTO)
    {
        try
        {
            string resetToken = _userBL.ForgetPassword(forgetPasswordDTO);
            return Ok(new ResponseDTO<string>
            {
                Success = true,
                Message = "Reset token generated. (Wire this up to an email service later.)",
                Data = resetToken
            });
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // POST /api/user/reset-password
    // Uses the reset token to set a brand-new password.
    [HttpPost("reset-password")]
    public IActionResult ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
    {
        try
        {
            string message = _userBL.ResetPassword(resetPasswordDTO);
            return Ok(new ResponseDTO<string> { Success = true, Message = message });
        }
        catch (InvalidCredentialsException ex)
        {
            // 400 Bad Request - token invalid/expired.
            return BadRequest(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }
}
