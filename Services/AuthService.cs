using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioTechSub.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly Context _context;

        public AuthService(IConfiguration config, Context context)
        {
            this._config = config;
            this._context = context;
        }

        public async Task<User> Authenticate(Login login)
        {
            var passwordEncoded = Password.ConvertPassword(login.Password);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == login.Username && x.Password == passwordEncoded);
            return user;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
