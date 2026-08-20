namespace FundooNotesApp.BusinessLayer.Helpers;

// BEGINNER NOTE: We never save a password as plain text in the
// database. Instead we "hash" it - turn it into a scrambled string
// that can't be reversed back into the original password.
//
// BCrypt is a trusted, battle-tested library made exactly for this job
// (it also adds "salt" automatically, so two users with the same
// password still get different hashes).
public static class PasswordHelper
{
    // Turns a plain password into a safe-to-store hash.
    public static string CreateHash(string plainTextPassword)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
    }

    // Checks whether a typed-in password matches a previously stored hash.
    public static bool IsMatch(string plainTextPassword, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(plainTextPassword, storedHash);
    }
}
