using Bonfire.Domain.Entities;
using Bonfire.Application.Interfaces;
using Bonfire.Domain.Entities;


namespace Bonfire.Tests.Mocks
{
    public class MockProjectRepository : IProjectRepository
    {

        public Project? ProjectToReturn { get; set; }

        public Task<Project?> GetByIdAsync(Guid id)
        {
            return Task.FromResult<Project?>(ProjectToReturn);
        }

        public Task AddAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        

        public Task UpdateAsync(Project project)
        {
            throw new NotImplementedException();
        }
    }
}

