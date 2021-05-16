using System;

namespace Lazy.Abp.WalletKit.PaymentSettings.Dtos
{
    [Serializable]
    public class PaymentSettingCreateUpdateDto
    {
        public PaymentGateway Gateway { get; set; }

        public string GatewayUrl { get; set; }

        public string ReturnUrl { get; set; }

        public string NotifyUrl { get; set; }

        public bool IsActive { get; set; }
    }
}