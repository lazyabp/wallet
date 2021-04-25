using System;
using System.Collections.Generic;
using System.Text;

namespace LazyAbp.WalletKit.Financial.Settings
{
    public class WeiXinSetting
    {
        public string AppId { get; set; }

        public string MerchantId { get; set; }

        public string Key { get; set; }

        public string AppSecret { get; set; }

        public string SslCertPath { get; set; }

        public string SslCertPassword { get; set; }
    }
}
