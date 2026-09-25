using Bonfire.Application.DTOs.Users;
using Bonfire.Application.Interfaces;
using Bonfire.Domain.Entities;


namespace Bonfire.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;


        public UserService(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        
        public async Task RegisterAsync(RegisterUserDto registerUserDto)
        {
            var existingUser = await _repository.GetUserByEmailAsync(registerUserDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            var passwordHash = _passwordHasher.HashPassword(registerUserDto.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                DisplayName = registerUserDto.DisplayName,
                Email = registerUserDto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(user);
        }
    }
}
