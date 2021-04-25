using System;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    [Serializable]
    public class CreateUpdateWalletLogDto
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