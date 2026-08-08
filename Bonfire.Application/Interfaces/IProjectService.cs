using Bonfire.Application.DTOs.Projects;

namespace Bonfire.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectSummaryDto>> GetAllAsync();

    Task<ProjectDto?> GetByIdAsync(Guid id);

    Task<ProjectDto> CreateAsync(CreateProjectDto request);

    Task<bool> UpdateAsync(Guid id, UpdateProjectDto request);

    Task<bool> DeleteAsync(Guid id);
}
