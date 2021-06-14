using System;

namespace Lazy.Abp.WalletKit.Withdraws.Dtos
{
    [Serializable]
    public class WithdrawAccountCreateUpdateDto
    {
        public AccountType AccountType { get; set; }

        public string Account { get; set; }

        public bool IsDefault { get; set; }

        public string Description { get; set; }
    }
}