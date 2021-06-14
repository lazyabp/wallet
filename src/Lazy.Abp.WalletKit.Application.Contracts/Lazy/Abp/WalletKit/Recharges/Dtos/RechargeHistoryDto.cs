using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.Recharges.Dtos
{
    [Serializable]
    public class RechargeHistoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid RechargeProductId { get; set; }

        public int Quantity { get; set; }

        public string OrderId { get; set; }

        public int CreditAmount { get; set; }

        public decimal PaidAmount { get; set; }
    }
}