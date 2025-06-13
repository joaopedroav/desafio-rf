using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioTechSub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public ActionResult<User> CreateUser(User user)
        {
            _service.CreateUser(user.Username, user.Password);
            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }

        [Authorize]
        [HttpPost("update")]
        public ActionResult<User> UpdateUser(User user)
        {
            _service.UpdateUser(user);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<User> GetUserByIdAsync(Guid id)
        {
            return Ok(_service.GetUserByIdAsync(id));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _service.DeleteUserByIdAsync(id);

            return Ok();
        }

        [Authorize]
        [HttpGet("report/getCurrentUsersBySubscription")]
        public ActionResult<IEnumerable<UserReport>> GetCurrentUsersBySubscription()
        {
            return Ok(_service.GetCurrentUsersBySubscription());
        }
    }
}
