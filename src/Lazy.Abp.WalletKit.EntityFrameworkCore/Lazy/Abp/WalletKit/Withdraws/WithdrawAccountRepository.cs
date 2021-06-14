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

namespace Lazy.Abp.WalletKit.Withdraws
{
    public class WithdrawAccountRepository : EfCoreRepository<IWalletKitDbContext, WithdrawAccount, Guid>, IWithdrawAccountRepository
    {
        public WithdrawAccountRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            AccountType? accountType = null,
            bool? isDefault = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, accountType, isDefault, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<WithdrawAccount>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            AccountType? accountType = null,
            bool? isDefault = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, accountType, isDefault, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<WithdrawAccount>> GetListQuery(
            Guid? userId = null,
            AccountType? accountType = null,
            bool? isDefault = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => e.CreatorId == userId)
                .WhereIf(accountType.HasValue, e => e.AccountType == accountType)
                .WhereIf(isDefault.HasValue, e => e.IsDefault == isDefault)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Description.Contains(filter)
                );
        }
    }
}