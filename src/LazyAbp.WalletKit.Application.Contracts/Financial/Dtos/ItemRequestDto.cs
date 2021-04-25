using System;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class ItemRequestDto
    {
        public Guid RechargeProductId { get; set; }

        public int Quantity { get; set; }
    }
}