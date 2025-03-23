using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore_sample_dependency_injection.Interface;
using netcore_sample_dependency_injection.Model;

namespace netcore_sample_dependency_injection.Controllers
{
    // User Controller

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
    }

}
