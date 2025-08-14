using Domain.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TaskManagementAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service) => _service = service;

        [HttpPost("User")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var result = await _service.CreateUserAsync(dto);
            return CreatedAtAction(nameof(CreateUser), new { id = result.Id }, result);
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto dto)
        {
            var result = await _service.UpdateUserAsync(id, dto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _service.DeleteUserAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _service.GetUserByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _service.GetAllUsersAsync();
            return Ok(result);
        }

       
    }
}
