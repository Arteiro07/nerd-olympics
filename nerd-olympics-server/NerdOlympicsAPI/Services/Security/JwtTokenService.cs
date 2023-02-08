using Microsoft.IdentityModel.Tokens;
using NerdOlympicsAPI.Interfaces;
using Custom = NerdOlympics.Data.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NerdOlympicsAPI.Services.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _secret;
        public readonly string _tokenIssuer;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtTokenService(IConfiguration configuration)
        {
            _secret =  configuration["JwtSecret"] ?? throw new InvalidOperationException("JwtSecretNotFound");
            _tokenIssuer =  configuration["TokenIssuer"] ?? throw new InvalidOperationException("TokenIssuerNotFound");
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(int userId, bool isAdmin)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>() { new Claim(Custom.ClaimTypes.Authenticated, userId.ToString()) };

            if(isAdmin)
                claims.Add(new Claim(Custom.ClaimTypes.Admin, userId.ToString()));

            // TODO add here the claim with the competitions that the user manages/can edit

            var token = new JwtSecurityToken(
                issuer: _tokenIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return _tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal? GetPrincipalFromToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = _tokenIssuer,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret))
                };

                var claimsPrincipal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return claimsPrincipal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secret));
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _tokenIssuer,
                    ValidateLifetime = true,
                    IssuerSigningKey = key
                };

                _tokenHandler.ValidateToken(token, validationParameters, out _);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
