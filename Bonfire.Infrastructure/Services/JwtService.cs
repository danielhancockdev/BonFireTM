using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bonfire.Application.DTOs.Users;
using Bonfire.Application.Interfaces;
using Bonfire.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bonfire.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _settings;

        public JwtService(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        public LoginResponseDto GenerateToken(Guid userId, string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.Key));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);
            var expiresAt = DateTime.UtcNow.AddHours(1);
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials);

            var tokenString =  new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponseDto
            {
                Token = tokenString,
                ExpiresAt = expiresAt
            };

        }
    }
}
