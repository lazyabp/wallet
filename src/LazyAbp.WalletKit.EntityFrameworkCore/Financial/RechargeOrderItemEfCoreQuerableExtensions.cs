using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public static class RechargeOrderItemEfCoreQueryableExtensions
    {
        public static IQueryable<RechargeOrderItem> IncludeDetails(this IQueryable<RechargeOrderItem> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}