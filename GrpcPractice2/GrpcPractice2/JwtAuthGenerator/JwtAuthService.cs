using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GrpcPractice2.JwtAuthGenerator;

public interface IJwtAuthService
{
    string? Authenticate(string username, string password);
}
 
public class JwtAuthService : IJwtAuthService
{
    readonly IDictionary<string, string> _users = new Dictionary<string, string>
    {
        { "test1", "password1" },
        { "test2", "password2" }
    };
 
    private readonly string _tokenKey = "TestTokenKeyJwtTokenKeyTestItFromTestTestTokenKeyJwtTokenKeyTestItFromTest";

    public string? Authenticate(string username, string password)
    {
        if (!_users.Any(u => u.Key == username && u.Value == password))
        {
            return null;
        }
 
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}