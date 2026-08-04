using Bonfire.Application.Interfaces;
using Bonfire.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Bonfire.Application.DTOs;

namespace Bonfire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _repository;

        public ProjectsController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _repository.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto request)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repository.AddAsync(project);

            return CreatedAtAction(
                nameof(GetById),
                new { id = project.Id },
                project);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest("Project ID does not match.");
            }

            var existingProject = await _repository.GetByIdAsync(id);

            if (existingProject == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(project);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(project);

            return NoContent();
        }

    }
}
