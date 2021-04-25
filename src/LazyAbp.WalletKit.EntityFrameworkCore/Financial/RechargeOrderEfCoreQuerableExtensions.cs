using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public static class RechargeOrderEfCoreQueryableExtensions
    {
        public static IQueryable<RechargeOrder> IncludeDetails(this IQueryable<RechargeOrder> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.Items) // TODO: AbpHelper generated
                ;
        }
    }
}