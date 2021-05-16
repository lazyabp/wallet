using Lazy.Abp.WalletKit.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.WalletKit.PaymentSettings.Dtos
{
    public class PaymentSettingAlipayDto : CreateUpdatePaymentSettingDto
    {
        public AlipaySetting Settings { get; set; }
    }
}
