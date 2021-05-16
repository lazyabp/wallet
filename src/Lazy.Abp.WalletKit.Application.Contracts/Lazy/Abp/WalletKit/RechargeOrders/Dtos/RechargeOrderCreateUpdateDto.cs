using System;
using System.Collections.Generic;

namespace Lazy.Abp.WalletKit.RechargeOrders.Dtos
{
    [Serializable]
    public class RechargeOrderCreateUpdateDto
    {
        public List<ItemRequestDto> Items { get; set; }
    }
}
