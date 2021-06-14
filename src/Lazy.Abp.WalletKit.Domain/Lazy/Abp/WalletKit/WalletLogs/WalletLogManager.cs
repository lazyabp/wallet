using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Lazy.Abp.WalletKit.WalletLogs
{
    public class WalletLogManager : DomainService
    {
        private readonly IWalletLogRepository _walletLogRepository;

        public WalletLogManager(IWalletLogRepository walletLogRepository)
        {
            _walletLogRepository = walletLogRepository;
        }

        /// <summary>
        /// 出账日志
        /// </summary>
        /// <returns></returns>
        public async Task WriteOutLogAsync(Guid? tenantId, Guid userId, string action, decimal amount, decimal currentBalance, string title, string description)
        {
            var log = new WalletLog(GuidGenerator.Create(), tenantId, userId, action, true, amount, currentBalance, title, description);
            await _walletLogRepository.InsertAsync(log);
        }

        /// <summary>
        /// 入账日志
        /// </summary>
        /// <returns></returns>
        public async Task WriteInLogAsync(Guid? tenantId, Guid userId, string action, decimal amount, decimal currentBalance, string title, string description)
        {
            var log = new WalletLog(GuidGenerator.Create(), tenantId, userId, action, false, amount, currentBalance, title, description);
            await _walletLogRepository.InsertAsync(log);
        }
    }
}
