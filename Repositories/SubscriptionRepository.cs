using DesafioTechSub.IRepositories;
using DesafioTechSub.Models;
using DesafioTechSub.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DesafioTechSub.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private Context _context;

        public SubscriptionRepository(Context context)
        {
            this._context = context;
        }

        public ActionResult<IEnumerable<RevenueReport>> GetMonthlyRevenue()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT EXTRACT(MONTH FROM your_date_column) AS Month, ");
            sql.AppendLine("SubscriptionValue ");
            sql.AppendLine("FROM Subscription ");
            sql.AppendLine("GROUP BY Month, Subscription ");
            sql.AppendLine("ORDER BY Month; ");
            return _context.RevenueReports
            .FromSqlRaw(sql.ToString())
            .AsNoTracking()
            .ToList();
        }
    }
}
