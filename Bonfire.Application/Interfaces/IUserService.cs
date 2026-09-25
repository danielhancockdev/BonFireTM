using Bonfire.Application.DTOs.Users;

namespace Bonfire.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDto request);

        Task LoginUserAsync(LoginUserDto request);
    }
}
