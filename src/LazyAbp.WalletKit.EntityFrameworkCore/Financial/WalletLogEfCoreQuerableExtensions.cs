using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public static class WalletLogEfCoreQueryableExtensions
    {
        public static IQueryable<WalletLog> IncludeDetails(this IQueryable<WalletLog> queryable, bool include = true)
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