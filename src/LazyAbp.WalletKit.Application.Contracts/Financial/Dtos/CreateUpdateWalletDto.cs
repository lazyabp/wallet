using System;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class CreateUpdateWalletDto
    {
        public Guid UserId { get; set; }

        public decimal Balance { get; set; }

        public decimal LockedAmount { get; set; }
    }
}