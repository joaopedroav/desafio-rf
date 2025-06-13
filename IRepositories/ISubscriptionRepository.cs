using DesafioTechSub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.IRepositories
{
    public interface ISubscriptionRepository
    {
        ActionResult<IEnumerable<RevenueReport>> GetMonthlyRevenue();
    }
}
