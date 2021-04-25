using System;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class CreateUpdateWithdrawAccountDto
    {
        public AccountType AccountType { get; set; }

        public string Account { get; set; }

        public bool IsDefault { get; set; }

        public string Description { get; set; }
    }
}