using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class RechargeOrderDto : FullAuditedEntityDto<Guid>
    {
        public decimal Amount { get; set; }

        public PaymentGateway? Gateway { get; set; }

        public PaymentStatus Status { get; set; }

        public string OrderNo { get; set; }

        public string TradeNo { get; set; }

        public DateTime? PaymentTime { get; set; }

        public bool IsClosed { get; set; }

        public List<RechargeOrderItemDto> Items { get; set; }
    }
}