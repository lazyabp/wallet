using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.WalletKit.Financial
{
    public interface IPaymentSettingRepository : IRepository<PaymentSetting, Guid>
    {
        Task<PaymentSetting> GetByGatewayAsync(PaymentGateway gateway, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            PaymentGateway? gateway = null,
            bool? isActive = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<PaymentSetting>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            PaymentGateway? gateway = null,
            bool? isActive = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}