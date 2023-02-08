using System.Security.Claims;

namespace NerdOlympicsAPI.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(int username, bool isAdmin);
        bool ValidateToken(string token);
        ClaimsPrincipal? GetPrincipalFromToken(string token);
    }
}
