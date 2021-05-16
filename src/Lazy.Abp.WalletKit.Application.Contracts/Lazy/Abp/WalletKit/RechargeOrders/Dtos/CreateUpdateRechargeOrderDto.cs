using System;
using System.Collections.Generic;

namespace Lazy.Abp.WalletKit.RechargeOrders.Dtos
{
    [Serializable]
    public class CreateUpdateRechargeOrderDto
    {
        public List<ItemRequestDto> Items { get; set; }
    }
}
