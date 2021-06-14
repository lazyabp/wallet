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

namespace Lazy.Abp.WalletKit.Recharges
{
    public class RechargeProductRepository : EfCoreRepository<IWalletKitDbContext, RechargeProduct, Guid>, IRechargeProductRepository
    {
        public RechargeProductRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<RechargeProduct>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => ids.Contains(q.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            bool? isActive = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, minPrice, maxPrice, creationAfter, creationBefore, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<RechargeProduct>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            bool? isActive = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, minPrice, maxPrice, creationAfter, creationBefore, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<RechargeProduct>> GetListQuery(
            bool? isActive = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                .WhereIf(minPrice.HasValue, e => e.SalePrice >= minPrice)
                .WhereIf(maxPrice.HasValue, e => e.SalePrice < maxPrice)
                .WhereIf(creationAfter.HasValue, e => e.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.Name.Contains(filter)
                    || e.Description.Contains(filter)
                );
        }
    }
}