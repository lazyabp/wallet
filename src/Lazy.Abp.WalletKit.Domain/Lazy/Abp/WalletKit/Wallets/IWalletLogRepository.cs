using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.WalletKit.Wallets
{
    public interface IWalletLogRepository : IRepository<WalletLog, Guid>
    {
        Task<long> GetCountAsync(
            Guid? userId = null,
            bool? isOut = null,
            string typeName = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<WalletLog>> GetListAsync(
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
        );
    }
}