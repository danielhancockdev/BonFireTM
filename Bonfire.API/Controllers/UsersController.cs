using Bonfire.Application.Interfaces;
using Bonfire.Application.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bonfire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser(RegisterUserDto request) 
        {
            //Never return User, User Contains passwordHash (DTO is important)
            await _service.RegisterAsync(request);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto request)
        {
            await _service.LoginUserAsync(request);
            return StatusCode(201);
        }
    }
}
