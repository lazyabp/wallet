using System;

namespace Lazy.Abp.WalletKit.WalletLogs.Dtos
{
    [Serializable]
    public class WalletLogCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public string TypeName { get; set; }

        public bool IsOut { get; set; }

        public decimal Amount { get; set; }

        public decimal CurrentBalance { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}