using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.WithdrawAccounts.Dtos
{
    [Serializable]
    public class WithdrawAccountDto : FullAuditedEntityDto<Guid>
    {
        public AccountType AccountType { get; set; }

        public string Account { get; set; }

        public bool IsDefault { get; set; }

        public string Description { get; set; }
    }
}