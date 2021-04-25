using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public static class RechargeProductEfCoreQueryableExtensions
    {
        public static IQueryable<RechargeProduct> IncludeDetails(this IQueryable<RechargeProduct> queryable, bool include = true)
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