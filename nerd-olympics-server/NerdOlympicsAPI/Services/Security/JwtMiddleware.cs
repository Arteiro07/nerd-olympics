using NerdOlympicsAPI.Interfaces;
using System.Security.Claims;

namespace NerdOlympicsAPI.Services.Security
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtTokenService _jwtTokenService;

        public JwtMiddleware(RequestDelegate next, IJwtTokenService jwtTokenService)
        {
            _next = next;
            _jwtTokenService = jwtTokenService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                ClaimsPrincipal? claimsPrincipal = _jwtTokenService.GetPrincipalFromToken(token);

                if (claimsPrincipal != null)
                {
                    context.User = claimsPrincipal;
                }
            }

            await _next(context);
        }
    }

}
