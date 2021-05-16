using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.Wallets.Dtos
{
    [Serializable]
    public class WalletDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public decimal Balance { get; set; }

        public decimal LockedAmount { get; set; }
    }
}