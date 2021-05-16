using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.RechargeOrders.Dtos
{
    [Serializable]
    public class RechargeOrderItemDto
    {
        public Guid RechargeOrderId { get; set; }

        public Guid RechargeProductId { get; set; }

        public decimal ItemPrice { get; set; }

        public int Quantity { get; set; }
    }
}