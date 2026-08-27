using System.ComponentModel.DataAnnotations;

namespace FundooNotesApp.ModelLayer.Entities;

// ENTITY = this is the exact shape of ONE ROW inside the "Users" table
// in the database. Entity Framework Core uses this class to create the
// table columns for us.
//
// Rule of thumb: an Entity is only ever used INSIDE the app (Business +
// Repository layer). We never hand this class straight to the client -
// that's what DTOs and UserModel are for.
public class UserEntity
{
    // Primary key - the database fills this in automatically for us.
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = "";

    [MaxLength(50)]
    public string LastName { get; set; } = "";

    // Used as the "username" for login. Kept unique at the business-logic level.
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = "";

    // We NEVER store the plain password here - only the hashed version
    // produced by BCrypt (see PasswordHelper in the Business layer).
    [Required]
    [MaxLength(256)]
    public string PasswordHash { get; set; } = "";

    // These two used to power the "forgot password" flow directly,
    // but that responsibility has moved to Redis (see
    // IResetTokenCache / RedisResetTokenCache) so tokens get an
    // automatic expiry without a manual date check. Left here,
    // unused, rather than dropping the columns via a migration.
    [MaxLength(100)]
    public string? ResetToken { get; set; }

    public DateTime? ResetTokenExpiry { get; set; }
}
