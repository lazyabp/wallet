using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public static class WalletEfCoreQueryableExtensions
    {
        public static IQueryable<Wallet> IncludeDetails(this IQueryable<Wallet> queryable, bool include = true)
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