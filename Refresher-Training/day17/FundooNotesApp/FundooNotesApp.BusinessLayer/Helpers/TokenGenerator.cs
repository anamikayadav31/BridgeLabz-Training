using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FundooNotesApp.BusinessLayer.Helpers;

// BEGINNER NOTE: After a successful login, we don't ask the user to
// send their email + password on every single request - instead we
// give them a "JWT" (JSON Web Token): a signed, tamper-proof string
// that proves who they are for a limited time (2 hours here).
//
// The client stores this token and sends it back in the
// "Authorization: Bearer <token>" header on future requests.
public class TokenGenerator
{
    private readonly string _secretKey;

    // The secret key is read from appsettings.json and passed in once,
    // when the app starts (see Program.cs).
    public TokenGenerator(string secretKey)
    {
        _secretKey = secretKey;
    }

    public string CreateTokenFor(int userId, string email)
    {
        // The signing key proves the token really came from OUR server -
        // nobody can forge a valid token without knowing this secret.
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        // "Claims" are little facts about the user, baked into the token
        // itself - so we don't need a database lookup just to know who
        // is making a request.
        var claims = new[]
        {
            new Claim("UserId", userId.ToString()),
            new Claim(ClaimTypes.Email, email)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
