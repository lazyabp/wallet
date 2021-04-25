using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using LazyAbp.WalletKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.WalletKit.Financial
{
    public class PaymentSettingRepository : EfCoreRepository<IWalletKitDbContext, PaymentSetting, Guid>, IPaymentSettingRepository
    {
        public PaymentSettingRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<PaymentSetting> GetByGatewayAsync(PaymentGateway gateway, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.Gateway == gateway)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            PaymentGateway? gateway = null,
            bool? isActive = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(gateway, isActive, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<PaymentSetting>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            PaymentGateway? gateway = null,
            bool? isActive = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(gateway, isActive, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<PaymentSetting>> GetListQuery(
            PaymentGateway? gateway = null,
            bool? isActive = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet.AsNoTracking()
                .WhereIf(gateway.HasValue, e => e.Gateway == gateway)
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive.Value);
        }
    }
}