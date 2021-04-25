using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public static class WithdrawAccountEfCoreQueryableExtensions
    {
        public static IQueryable<WithdrawAccount> IncludeDetails(this IQueryable<WithdrawAccount> queryable, bool include = true)
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