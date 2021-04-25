using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
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