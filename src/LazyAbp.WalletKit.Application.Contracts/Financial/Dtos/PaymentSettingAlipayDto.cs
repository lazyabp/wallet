using LazyAbp.WalletKit.Financial.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    public class PaymentSettingAlipayDto : CreateUpdatePaymentSettingDto
    {
        public AlipaySetting Settings { get; set; }
    }
}
