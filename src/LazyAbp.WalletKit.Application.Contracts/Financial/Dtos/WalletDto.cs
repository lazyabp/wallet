using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class WalletDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public decimal Balance { get; set; }

        public decimal LockedAmount { get; set; }
    }
}