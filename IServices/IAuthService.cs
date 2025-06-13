using DesafioTechSub.Models;

namespace DesafioTechSub.IServices
{
    public interface IAuthService
    {
        string GenerateToken(User user);
        Task<User> Authenticate(Login login);
    }
}
