using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.DTOs.RequestDTO;

// The client sends back the reset token (received via the forgot-password
// step) plus the new password they want to set.
public class ResetPasswordDTO
{
    [Required(ErrorMessage = "Reset token is required")]
    public string Token { get; set; } = "";

    [Required(ErrorMessage = "New password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    [MaxLength(20, ErrorMessage = "Password cannot be longer than 20 characters")]
    public string NewPassword { get; set; } = "";
}
