using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public static class PaymentSettingEfCoreQueryableExtensions
    {
        public static IQueryable<PaymentSetting> IncludeDetails(this IQueryable<PaymentSetting> queryable, bool include = true)
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