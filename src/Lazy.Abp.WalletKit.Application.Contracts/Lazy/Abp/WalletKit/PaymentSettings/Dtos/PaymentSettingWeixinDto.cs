using Lazy.Abp.WalletKit.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.WalletKit.PaymentSettings.Dtos
{
    public class PaymentSettingWeixinDto : CreateUpdatePaymentSettingDto
    {
        public WeiXinSetting Settings { get; set; }
    }
}
