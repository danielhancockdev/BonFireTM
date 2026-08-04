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
        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

    }
}
