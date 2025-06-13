using DesafioTechSub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.IServices
{
    public interface IUserService
    {
        Task<User> CreateUser(string username, string password);
        Task<User> UpdateUser(User user);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> DeleteUserByIdAsync(Guid id);
        ActionResult<IEnumerable<UserReport>> GetCurrentUsersBySubscription();
    }
}
