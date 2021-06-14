using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.Wallets.Dtos
{
    [Serializable]
    public class WalletLogDto : CreationAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public string TypeName { get; set; }

        public bool IsOut { get; set; }

        public decimal Amount { get; set; }

        public decimal CurrentBalance { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}