using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.WalletKit.Withdraws
{
    public interface IWithdrawAccountRepository : IRepository<WithdrawAccount, Guid>
    {
        Task<long> GetCountAsync(
            Guid? userId = null,
            AccountType? accountType = null,
            bool? isDefault = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<WithdrawAccount>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            AccountType? accountType = null,
            bool? isDefault = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}