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
    public class RechargeOrderRepository : EfCoreRepository<IWalletKitDbContext, RechargeOrder, Guid>, IRechargeOrderRepository
    {
        public RechargeOrderRepository(IDbContextProvider<IWalletKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<RechargeOrder> GetByIdAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .IncludeDetails(includeDetails)
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<RechargeOrder> GetByOrderNoAsync(string orderNO, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .IncludeDetails(includeDetails)
                .Where(q => q.OrderNo == orderNO)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<RechargeOrder> GetByTradeNoAsync(string tradeNO, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .IncludeDetails(includeDetails)
                .Where(q => q.TradeNo == tradeNO)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            bool? isClosed = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, gateway, status, isClosed, minAmount, maxAmount, creationAfter, creationBefore, filter, includeDetails);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<RechargeOrder>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            bool? isClosed = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, gateway, status, isClosed, minAmount, maxAmount, creationAfter, creationBefore, filter, includeDetails);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<RechargeOrder>> GetListQuery(
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            bool? isClosed = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .IncludeDetails(includeDetails)
                .WhereIf(userId.HasValue, e => e.CreatorId == userId)
                .WhereIf(gateway.HasValue, e => e.Gateway == gateway)
                .WhereIf(status.HasValue, e => e.Status == status)
                .WhereIf(isClosed.HasValue, e => e.IsClosed == isClosed)
                .WhereIf(minAmount.HasValue, e => e.Amount >= minAmount)
                .WhereIf(maxAmount.HasValue, e => e.Amount < maxAmount)
                .WhereIf(creationAfter.HasValue, e => e.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.OrderNo.Contains(filter)
                    || e.TradeNo.Contains(filter)
                );
        }
    }
}