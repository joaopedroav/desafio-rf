using DesafioTechSub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.IRepositories
{
    public interface IUserRepository
    {
        ActionResult<IEnumerable<UserReport>> GetCurrentUsersBySubscription();
    }
}
