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

namespace Lazy.Abp.WalletKit.Wallets
{
    public class WalletLogRepository : EfCoreRepository<IWalletKitDbContext, WalletLog, Guid>, IWalletLogRepository
    {
        public WalletLogRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            bool? isOut = null,
            string typeName = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, isOut, typeName, minAmount, maxAmount, creationAfter, creationBefore, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<WalletLog>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            bool? isOut = null,
            string typeName = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, isOut, typeName, minAmount, maxAmount, creationAfter, creationBefore, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<WalletLog>> GetListQuery(
            Guid? userId = null,
            bool? isOut = null,
            string typeName = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(isOut.HasValue, e => e.IsOut == isOut)
                .WhereIf(!typeName.IsNullOrEmpty(), e => e.TypeName == typeName)
                .WhereIf(minAmount.HasValue, e => e.Amount >= minAmount)
                .WhereIf(maxAmount.HasValue, e => e.Amount < maxAmount)
                .WhereIf(creationAfter.HasValue, e => e.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.Title.Contains(filter)
                    || e.Description.Contains(filter)
                );
        }
    }
}