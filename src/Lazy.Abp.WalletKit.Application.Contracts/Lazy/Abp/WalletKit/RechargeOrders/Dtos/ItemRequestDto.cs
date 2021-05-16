using System;

namespace Lazy.Abp.WalletKit.RechargeOrders.Dtos
{
    [Serializable]
    public class ItemRequestDto
    {
        public Guid RechargeProductId { get; set; }

        public int Quantity { get; set; }
    }
}