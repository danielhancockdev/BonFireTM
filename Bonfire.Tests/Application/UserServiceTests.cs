using Bonfire.Application.DTOs.Users;
using Bonfire.Application.Services;
using Bonfire.Domain.Entities;
using Bonfire.Tests.Mocks;

namespace Bonfire.Tests.Application
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterAsync_WhereUserIsNotNull()
        {
            //Arrange
            var respository = new MockUserRepository()
            {
                UserToReturn = new User
                {
                    Id = Guid.NewGuid(),
                    DisplayName = "Existing User",
                    Email = "Mock@Mock.com",
                    PasswordHash = "existing-hash"
                }
            };
            var registerUserDto = new RegisterUserDto
            {
                DisplayName = "AttemptUser",
                Email = "Mock@Mock.com",
                Password = "AttemptPassword"
            };

            var passwordHasher = new MockPasswordHasher();
            var jwtService = new MockJwtService();
            var service = new UserService(respository, passwordHasher, jwtService);
            //Act and Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => service.RegisterAsync(registerUserDto));
            Assert.Equal("A user with this email already exists.", exception.Message);
        }
    }
}
