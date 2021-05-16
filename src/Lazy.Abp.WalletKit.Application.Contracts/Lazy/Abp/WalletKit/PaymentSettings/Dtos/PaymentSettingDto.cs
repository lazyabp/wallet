using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.PaymentSettings.Dtos
{
    [Serializable]
    public class PaymentSettingDto : FullAuditedEntityDto<Guid>
    {
        public PaymentGateway Gateway { get; set; }

        public string GatewayUrl { get; set; }

        public string ReturnUrl { get; set; }

        public string NotifyUrl { get; set; }

        public bool IsActive { get; set; }
    }
}