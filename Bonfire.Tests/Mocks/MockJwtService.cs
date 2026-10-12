using Bonfire.Application.DTOs.Users;
using Bonfire.Application.Interfaces;

namespace Bonfire.Tests.Mocks
{
    public class MockJwtService : IJwtService
    {
        public LoginResponseDto GenerateToken(Guid userId, string email)
        {
            return new LoginResponseDto
            {
                Token = "MockJwtToken",
                ExpiresAt = new DateTime(2030, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };
        }
    }
}
