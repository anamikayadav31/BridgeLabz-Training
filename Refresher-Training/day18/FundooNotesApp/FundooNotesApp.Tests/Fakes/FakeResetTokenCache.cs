using FundooNotesApp.BusinessLayer.Interfaces;

namespace FundooNotesApp.Tests.Fakes;

// Same idea as FakeEmailQueuePublisher - a plain in-memory dictionary
// standing in for Redis, so tests stay fast and don't need a real
// Redis server running.
public class FakeResetTokenCache : IResetTokenCache
{
    private readonly Dictionary<string, string> _tokens = new();

    public void StoreResetToken(string token, string email, TimeSpan expiry)
    {
        // Expiry is ignored here on purpose - tests run in milliseconds,
        // well within any real TTL, so simulating expiry isn't needed.
        _tokens[token] = email;
    }

    public string? GetEmailForResetToken(string token) =>
        _tokens.TryGetValue(token, out var email) ? email : null;

    public void RemoveResetToken(string token) => _tokens.Remove(token);
}
