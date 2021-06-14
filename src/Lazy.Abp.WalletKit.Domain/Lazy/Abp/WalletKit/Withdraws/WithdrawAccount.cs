using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.WalletKit.Withdraws
{
    public class WithdrawAccount : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public AccountType AccountType { get; private set; }

        public string Account { get; private set; }

        public bool IsDefault { get; private set; }

        public string Description { get; private set; }

        protected WithdrawAccount()
        {
        }

        public WithdrawAccount(
            Guid id,
            Guid? tenantId,
            AccountType accountType,
            string account,
            bool isDefault,
            string description
        ) : base(id)
        {
            TenantId = tenantId;
            AccountType = accountType;
            Account = account;
            IsDefault = isDefault;
            Description = description;
        }

        public void Update(
            AccountType accountType,
            string account,
            bool isDefault,
            string description
        )
        {
            AccountType = accountType;
            Account = account;
            IsDefault = isDefault;
            Description = description;
        } 
    }
}
