using Bonfire.Application.DTOs.Users;

namespace Bonfire.Application.Interfaces
{
    public interface IJwtService
    {
        LoginResponseDto GenerateToken(Guid userId, string email);

    }
}
