using System;
using System.Collections.Generic;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class CreateUpdateRechargeOrderDto
    {
        public List<ItemRequestDto> Items { get; set; }
    }
}
