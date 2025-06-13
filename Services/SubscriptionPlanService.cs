using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.EntityFrameworkCore;

namespace DesafioTechSub.Services
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly Context _context;
        public SubscriptionPlanService(Context context)
        {
            _context = context;
        }

        public async Task<SubscriptionPlan> SaveSubscriptionPlan(SubscriptionPlan subscriptionPlan)
        {
            if (!subscriptionPlan.Id.HasValue)
                _context.Add(subscriptionPlan);
            else
                _context.Update(subscriptionPlan);

            await _context.SaveChangesAsync();
            return subscriptionPlan;
        }

        public async Task<bool> DeleteSubscriptionPlanByIdAsync(Guid id)
        {
            var subscriptionPlan = await _context.SubscriptionPlans.FirstOrDefaultAsync(x => x.Id == id);
            if (!(subscriptionPlan is object))
                return false;

            _context.SubscriptionPlans.Remove(subscriptionPlan);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<SubscriptionPlan>> GetAllSubscriptionPlansAsync()
        {
            return await _context.SubscriptionPlans.ToListAsync();
        }

        public async Task<SubscriptionPlan?> GetSubscriptionPlanByIdAsync(Guid id)
        {
            return await _context.SubscriptionPlans.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
