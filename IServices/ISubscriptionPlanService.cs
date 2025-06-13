using DesafioTechSub.Models;

namespace DesafioTechSub.IServices
{
    public interface ISubscriptionPlanService
    {
        Task<SubscriptionPlan> SaveSubscriptionPlan(SubscriptionPlan SubscriptionPlan);
        Task<SubscriptionPlan?> GetSubscriptionPlanByIdAsync(Guid id);
        Task<List<SubscriptionPlan>> GetAllSubscriptionPlansAsync();
        Task<bool> DeleteSubscriptionPlanByIdAsync(Guid id);
    }
}
