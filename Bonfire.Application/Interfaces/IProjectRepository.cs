using Bonfire.Domain.Entities;


namespace Bonfire.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();

        Task<Project?> GetByIdAsync(Guid id);

        Task AddAsync(Project project);

        Task UpdateAsync(Project project);

        Task DeleteAsync(Project project);
    }
}
