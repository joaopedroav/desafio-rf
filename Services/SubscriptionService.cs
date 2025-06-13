using DesafioTechSub.IRepositories;
using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioTechSub.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly Context _context;
        private readonly ISubscriptionRepository _repository;
        public SubscriptionService(Context context, ISubscriptionRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Subscription> SaveSubscription(Subscription subscription)
        {
            var exists = _context.Subscriptions.Any(x => x.UserId == subscription.UserId && !x.IsCanceled);
            if (exists)
                throw new Exception("Usuário já possui uma assinatura ativa");

            _context.Add(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<bool> DeleteSubscriptionByIdAsync(Guid id)
        {
            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
            if (!(subscription is object))
                return false;

            _context.Subscriptions.Remove(subscription);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription?> GetSubscriptionByIdAsync(Guid id)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Subscription> CancelSubscription(Guid id)
        {
            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
            subscription.IsCanceled = true;
            _context.Update(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public ActionResult<IEnumerable<RevenueReport>> GetMonthlyRevenue()
        {
            return _repository.GetMonthlyRevenue();
        }
    }
}
