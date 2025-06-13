using DesafioTechSub.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.IServices
{
    public interface ISubscriptionService
    {
        Task<Subscription> SaveSubscription(Subscription Subscription);
        Task<Subscription> CancelSubscription(Guid id);
        Task<Subscription?> GetSubscriptionByIdAsync(Guid id);
        Task<List<Subscription>> GetAllSubscriptionsAsync();
        Task<bool> DeleteSubscriptionByIdAsync(Guid id);
        ActionResult<IEnumerable<RevenueReport>> GetMonthlyRevenue();
    }
}
