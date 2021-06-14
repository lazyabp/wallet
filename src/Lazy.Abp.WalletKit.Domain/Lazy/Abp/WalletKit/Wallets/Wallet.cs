using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.WalletKit.Wallets
{
    public class Wallet : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid UserId { get; private set; }

        public decimal Balance { get; private set; }

        public decimal LockedAmount { get; private set; }

        protected Wallet()
        {
        }

        public Wallet(
            Guid id,
            Guid? tenantId,
            Guid userId,
            decimal balance,
            decimal lockedAmount
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            Balance = balance;
            LockedAmount = lockedAmount;
        }

        public void IncBalance(decimal amount)
        {
            Balance += Math.Abs(amount);
        }

        public void DecBalance(decimal amount)
        {
            if (Balance - Math.Abs(amount) < 0)
                throw new Exception("InsufficientBalance");

            Balance -= Math.Abs(amount);
        }

        public void IncLockedAmount(decimal amount)
        {
            LockedAmount += Math.Abs(amount);
        }

        public void DecLockedAmount(decimal amount)
        {
            LockedAmount -= Math.Abs(amount);
        }

        public void Reset()
        {
            Balance = 0;
            LockedAmount = 0;
        }
    }
}
