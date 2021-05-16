using System;

namespace Lazy.Abp.WalletKit.Wallets.Dtos
{
    [Serializable]
    public class WalletCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public decimal Balance { get; set; }

        public decimal LockedAmount { get; set; }
    }
}