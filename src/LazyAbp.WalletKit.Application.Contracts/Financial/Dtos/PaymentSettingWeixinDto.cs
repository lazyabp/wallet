using LazyAbp.WalletKit.Financial.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    public class PaymentSettingWeixinDto : CreateUpdatePaymentSettingDto
    {
        public WeiXinSetting Settings { get; set; }
    }
}
