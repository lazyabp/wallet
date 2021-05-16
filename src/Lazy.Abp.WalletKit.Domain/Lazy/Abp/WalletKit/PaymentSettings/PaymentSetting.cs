using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.WalletKit.PaymentSettings
{
    public class PaymentSetting : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public PaymentGateway Gateway { get; private set; }

        public string GatewayUrl { get; private set; }

        public string ReturnUrl { get; private set; }

        public string NotifyUrl { get; private set; }

        public bool IsActive { get; private set; }

        public string Settings { get; private set; }

        protected PaymentSetting()
        {
        }

        public PaymentSetting(
            Guid id,
            Guid? tenantId,
            PaymentGateway gateway,
            string gatewayUrl,
            string returnUrl,
            string notifyUrl,
            bool isActive
        ) : base(id)
        {
            TenantId = tenantId;
            Gateway = gateway;
            GatewayUrl = gatewayUrl;
            ReturnUrl = returnUrl;
            NotifyUrl = notifyUrl;
            IsActive = isActive;
        }

        public void Update(
            string gatewayUrl,
            string returnUrl,
            string notifyUrl,
            bool isActive
        )
        {
            GatewayUrl = gatewayUrl;
            ReturnUrl = returnUrl;
            NotifyUrl = notifyUrl;
            IsActive = isActive;
        }

        public void SetActive(bool isActive = true)
        {
            IsActive = isActive;
        }

        public void SetSettings(string settings)
        {
            Settings = settings;
        }
    }
}
