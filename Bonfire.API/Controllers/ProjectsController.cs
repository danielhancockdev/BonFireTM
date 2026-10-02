using Bonfire.Application.DTOs.Projects;
using Bonfire.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace Bonfire.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _service.GetAllAsync();

            return Ok(projects);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            // Grab user Id from the JWT
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = Guid.Parse(userIdClaim);

            // Grab Project by Id
            var project = await _service.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            var isOwner = project.OwnerId == userId;
            var isMember = project.Members.Any(member => member.Id == userId);

            if (!isOwner && !isMember)
            {
                return Forbid();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto request)
        {
            var project = await _service.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = project.Id },
                project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            Guid id,
            UpdateProjectDto request)
        {
            var updated = await _service.UpdateAsync(id, request);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}


