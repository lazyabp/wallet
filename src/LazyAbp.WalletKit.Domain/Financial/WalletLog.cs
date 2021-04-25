using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.WalletKit.Financial
{
    public class WalletLog : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid UserId { get; private set; }

        [MaxLength(FinancialConsts.MaxLength128)]
        public string TypeName { get; private set; }

        /// <summary>
        /// 收入或支出
        /// </summary>
        public bool IsOut { get; private set; }

        public decimal Amount { get; private set; }

        public decimal CurrentBalance { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        protected WalletLog()
        {
        }

        public WalletLog(
            Guid id,
            Guid? tenantId,
            Guid userId,
            string typeName,
            bool isOut,
            decimal amount,
            decimal currentBalance,
            string title,
            string description
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            TypeName = typeName;
            IsOut = isOut;
            CurrentBalance = currentBalance;
            Title = title;
            Description = description;

            if (IsOut)
                Amount = -Math.Abs(amount);
            else
                Amount = Math.Abs(amount);
        }
    }
}
