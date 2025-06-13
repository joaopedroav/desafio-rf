using DesafioTechSub.IRepositories;
using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioTechSub.Services
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        private readonly IUserRepository _repository;

        public UserService(Context context, IUserRepository repository) 
        {
            _context = context;
            _repository = repository;
        }

        public async Task<User> CreateUser(string username, string password)
        {
            User user = new User();
            user.Username = username;
            user.Password = Password.ConvertPassword(password);
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (!(user is object))
                return false;

            _context.Users.Remove(user);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public ActionResult<IEnumerable<UserReport>> GetCurrentUsersBySubscription()
        {
            return _repository.GetCurrentUsersBySubscription();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
