using Lazy.Abp.WalletKit.PaymentSettings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.WalletKit.RechargeOrders
{
    public interface IRechargeOrderRepository : IRepository<RechargeOrder, Guid>
    {
        Task<RechargeOrder> GetByIdAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<RechargeOrder> GetByOrderNoAsync(string orderNO, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<RechargeOrder> GetByTradeNoAsync(string tradeNO, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            bool? isClosed = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<RechargeOrder>> GetListAsync(
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
        );
    }
}