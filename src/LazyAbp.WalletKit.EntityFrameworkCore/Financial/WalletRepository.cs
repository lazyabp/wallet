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
    public class WalletRepository : EfCoreRepository<IWalletKitDbContext, Wallet, Guid>, IWalletRepository
    {
        public WalletRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Wallet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            bool hasLockedAmount = false,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, minBalance, maxBalance, hasLockedAmount, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<Wallet>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            bool hasLockedAmount = false,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, minBalance, maxBalance, hasLockedAmount, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<Wallet>> GetListQuery(
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            bool hasLockedAmount = false,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(hasLockedAmount, e => e.LockedAmount > 0)
                .WhereIf(minBalance.HasValue, e => e.Balance >= minBalance)
                .WhereIf(maxBalance.HasValue, e => e.Balance < maxBalance);
        }
    }
}