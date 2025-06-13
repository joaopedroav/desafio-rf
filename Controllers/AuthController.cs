using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user = await _authService.Authenticate(login);
            if (!(user is object))
                return Unauthorized();

            var token = _authService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
