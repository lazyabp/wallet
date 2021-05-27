using Lazy.Abp.WalletKit.RechargeProducts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.WalletKit.WalletActions
{
    public class WalletAction : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid UserId { get; private set; }

        public Guid RechargeProductId { get; private set; }

        public int Quantity { get; private set; }

        public string OrderId { get; private set; }

        /// <summary>
        /// 入账金额
        /// </summary>
        public int CreditAmount  { get; private set; }

        public decimal PaidAmount { get; private set; }

        public RechargeProduct RechargeProduct { get; private set; }

        protected WalletAction()
        {
        }

        public WalletAction(
            Guid id,
            Guid? tenantId,
            Guid userId,
            Guid rechargeProductId,
            int quantity,
            string orderId,
            int creditAmount,
            decimal paidAmount
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            RechargeProductId = rechargeProductId;
            Quantity = quantity;
            OrderId = orderId;
            CreditAmount = creditAmount;
            PaidAmount = paidAmount;
        }
    }
}
