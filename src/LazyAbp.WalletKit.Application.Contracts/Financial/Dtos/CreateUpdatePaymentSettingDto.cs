using System;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class CreateUpdatePaymentSettingDto
    {
        public PaymentGateway Gateway { get; set; }

        public string GatewayUrl { get; set; }

        public string ReturnUrl { get; set; }

        public string NotifyUrl { get; set; }

        public bool IsActive { get; set; }
    }
}