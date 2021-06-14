using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.WalletKit.Wallets.Dtos
{
    public class BalanceAdjustmentDto
    {
        public decimal Amount { get; set; } 

        public string Reason { get; set; }
    }
}
