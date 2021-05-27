using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.WalletActions.Dtos
{
    [Serializable]
    public class WalletActionDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid RechargeProductId { get; set; }

        public int Quantity { get; set; }

        public string OrderId { get; set; }

        public int CreditAmount { get; set; }

        public decimal PaidAmount { get; set; }
    }
}