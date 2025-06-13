using DesafioTechSub.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioTechSub.Utils
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<UserReport> UserReports { get; set; } = null!;
        public DbSet<RevenueReport> RevenueReports { get; set; } = null!;
    }
}
