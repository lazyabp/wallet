using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.WalletKit.Financial
{
    public interface IWalletRepository : IRepository<Wallet, Guid>
    {
        Task<Wallet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            bool hasLockedAmount = false,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<Wallet>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            bool hasLockedAmount = false,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}