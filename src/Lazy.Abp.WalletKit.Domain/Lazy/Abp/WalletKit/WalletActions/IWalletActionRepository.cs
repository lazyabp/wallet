using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.WalletKit.WalletActions
{
    public interface IWalletActionRepository : IRepository<WalletAction, Guid>
    {
        Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? coinProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<WalletAction>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            Guid? coinProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}