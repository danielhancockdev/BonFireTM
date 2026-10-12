using Bonfire.Application.Services;
using Bonfire.Tests.Mocks;

namespace Bonfire.Tests.Application
{
    public class ProjectServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_WhenProjectDoesNotExist_ReturnsNull()
        {
            //Arrange
            var repository = new MockProjectRepository
            {
                ProjectToReturn = null,
            };
            var service = new ProjectService(repository);
            var projectId = Guid.NewGuid();

            //Act
            var result = await service.GetByIdAsync(projectId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetbyIdAsync_WhenProjectDoesExits_ReturnsProjectDto()
        {
            //Arrange
            var projectId = Guid.NewGuid();
            var repository = new MockProjectRepository()
            {
                ProjectToReturn = new Domain.Entities.Project
                {
                    Id = projectId,
                    Name = "Test Project"
                }
            };
            var service = new ProjectService(repository);

            //Act
            var result = await service.GetByIdAsync(projectId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(projectId, result.Id);
            Assert.Equal("Test Project", result.Name);

        }
    }
}
