using FundooNotesApp.BusinessLayer.Interfaces;
using StackExchange.Redis;

namespace FundooNotesApp.BusinessLayer.Helpers;

// BEGINNER NOTE: before this, a password-reset token lived in the
// Users table itself (ResetToken / ResetTokenExpiry columns) - which
// meant every reset request was two extra writes to SQL Server, and
// the expiry had to be checked manually by comparing dates in code.
//
// Redis is built exactly for this kind of short-lived, key-based
// data: we store the token with a TTL (time-to-live), and Redis
// itself deletes it the moment it expires - no manual expiry check
// needed, and no permanent columns cluttering the Users table for
// something that only matters for 30 minutes.
public class RedisResetTokenCache : IResetTokenCache
{
    private readonly IDatabase _redisDb;

    // The connection string comes from appsettings.json
    // ("RedisSettings:ConnectionString") and is passed in once, when
    // the app starts (see Program.cs) - same pattern as every other
    // helper in this project.
    public RedisResetTokenCache(string connectionString)
    {
        var redis = ConnectionMultiplexer.Connect(connectionString);
        _redisDb = redis.GetDatabase();
    }

    public void StoreResetToken(string token, string email, TimeSpan expiry)
    {
        _redisDb.StringSet(ResetTokenKey(token), email, expiry);
    }

    public string? GetEmailForResetToken(string token)
    {
        RedisValue value = _redisDb.StringGet(ResetTokenKey(token));
        return value.IsNullOrEmpty ? null : value.ToString();
    }

    public void RemoveResetToken(string token)
    {
        _redisDb.KeyDelete(ResetTokenKey(token));
    }

    // Namespacing the key like this keeps reset-token entries easy to
    // spot in Redis if other kinds of cached data get added later.
    private static string ResetTokenKey(string token) => $"reset-token:{token}";
}
