using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.WalletKit.RechargeOrders
{
    public enum PaymentStatus
    {
        NotPaid = 1,
        Paid = 2,
        Failed = 3,
        Cancelled = 4,
        Completed = 5
    }
}
