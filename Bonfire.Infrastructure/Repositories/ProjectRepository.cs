using Bonfire.Application.Interfaces;
using Bonfire.Domain.Entities;
using Bonfire.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bonfire.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BonfireDbContext _context;

        public ProjectRepository(BonfireDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public Task<Project?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
