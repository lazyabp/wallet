using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.WalletKit.WalletActions
{
    public class WalletActionRepository : EfCoreRepository<IWalletKitDbContext, WalletAction, Guid>, IWalletActionRepository
    {
        public WalletActionRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<WalletAction>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.RechargeProduct);
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? rechargeProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, rechargeProductId, minPaidAmount, maxPaidAmount, creationAfter, creationBefore, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<WalletAction>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            Guid? rechargeProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, rechargeProductId, minPaidAmount, maxPaidAmount, creationAfter, creationBefore, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<WalletAction>> GetListQuery(
            Guid? userId = null,
            Guid? rechargeProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return (await GetQueryableAsync())
                .Include(q => q.RechargeProduct)
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(rechargeProductId.HasValue, e => e.RechargeProductId == rechargeProductId)
                .WhereIf(minPaidAmount.HasValue, e => e.PaidAmount >= minPaidAmount)
                .WhereIf(maxPaidAmount.HasValue, e => e.PaidAmount <= maxPaidAmount)
                .WhereIf(creationAfter.HasValue, e => e.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.OrderId.Contains(filter)
                    || e.RechargeProduct.Name.Contains(filter)
                );
        }
    }
}