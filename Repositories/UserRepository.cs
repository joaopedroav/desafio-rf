using DesafioTechSub.IRepositories;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DesafioTechSub.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
        {
            this._context = context;
        }

        public ActionResult<IEnumerable<UserReport>> GetCurrentUsersBySubscription()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT SubscriptionPlan.Name AS SubscriptionPlan, ");
            sql.AppendLine("User.Name AS User ");
            sql.AppendLine("FROM Subscription ");
            sql.AppendLine("INNER JOIN SubscriptionPlan ON Subscription.SubscriptionPlanId = SubscriptionPlan.Id ");
            sql.AppendLine("INNER JOIN User ON Subscription.UserId = User.Id ");
            sql.AppendLine("WHERE SubscriptionPlan.IsCanceled = FALSE ");
            sql.AppendLine("ORDER BY Subscription.Name; ");
            return _context.UserReports
            .FromSqlRaw(sql.ToString())
            .AsNoTracking()
            .ToList();
        }
    }
}
