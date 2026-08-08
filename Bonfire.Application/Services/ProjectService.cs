using Bonfire.Application.DTOs.Projects;
using Bonfire.Application.Interfaces;
using Bonfire.Domain.Entities;

namespace Bonfire.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProjectSummaryDto>> GetAllAsync()
    {
        var projects = await _repository.GetAllAsync();

        return projects.Select(project => new ProjectSummaryDto
        {
            Id = project.Id,
            Name = project.Name
        });
    }

    public async Task<ProjectDto?> GetByIdAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);

        if (project == null)
        {
            return null;
        }

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        };
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto request)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(project);

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        };
    }
    public async Task<bool> UpdateAsync(Guid id, UpdateProjectDto request)
    {
        var project = await _repository.GetByIdAsync(id);

        if (project == null)
        {
            return false;
        }

        project.Name = request.Name;
        project.Description = request.Description;
        project.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(project);

        return true;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);

        if (project == null)
        {
            return false;
        }

        await _repository.DeleteAsync(project);

        return true;
    }
}
