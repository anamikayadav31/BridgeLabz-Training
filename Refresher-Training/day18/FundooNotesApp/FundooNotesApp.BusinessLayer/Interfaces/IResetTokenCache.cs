namespace FundooNotesApp.BusinessLayer.Interfaces;

// Same "depend on the interface, not the real thing" pattern as
// IEmailQueuePublisher. UserBL only ever needs to store a token,
// look one up, and remove it once used - it doesn't need to know
// Redis is what's actually backing that.
public interface IResetTokenCache
{
    void StoreResetToken(string token, string email, TimeSpan expiry);

    // Returns the email the token was issued for, or null if the
    // token doesn't exist / has already expired in Redis.
    string? GetEmailForResetToken(string token);

    void RemoveResetToken(string token);
}
