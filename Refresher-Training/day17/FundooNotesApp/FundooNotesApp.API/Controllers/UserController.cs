using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.DTOs.ResponseDTO;
using FundooNotesApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

    // GET /api/user/profile
    // BEGINNER NOTE: [Authorize] is a "gatekeeper" - ASP.NET Core won't
    // even let this method run unless the request has a valid
    // "Authorization: Bearer <token>" header. If the token is missing,
    // expired, or signed with the wrong secret key, the framework
    // automatically sends back a 401 Unauthorized before our code runs.
    //
    // This is a simple way to prove the whole login system actually
    // works end-to-end: only someone holding a real token from /login
    // can reach this endpoint.
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        // When the token was created back in TokenGenerator.cs, we baked
        // "UserId" and the email into it as claims. Here we read those
        // same claims back out - no extra database call needed, the
        // token itself already carries this information.
        string? loggedInUserId = User.FindFirst("UserId")?.Value;
        string? loggedInEmail = User.FindFirst(ClaimTypes.Email)?.Value;

        return Ok(new ResponseDTO<object>
        {
            Success = true,
            Message = "Your token is valid - here's what it says about you.",
            Data = new { UserId = loggedInUserId, Email = loggedInEmail }
        });
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
