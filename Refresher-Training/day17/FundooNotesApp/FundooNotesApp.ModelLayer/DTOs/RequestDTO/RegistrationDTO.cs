using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.DTOs.RequestDTO;

// This is the exact JSON shape the client must send to sign up.
// The [Required]/[EmailAddress]/[MinLength] attributes are automatic
// validators - ASP.NET Core checks these BEFORE our code even runs,
// and rejects bad input with a 400 error on its own.
public class RegistrationDTO
{
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50)]
    public string FirstName { get; set; } = "";

    [MaxLength(50)]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    [MaxLength(20, ErrorMessage = "Password cannot be longer than 20 characters")]
    public string Password { get; set; } = "";
}
