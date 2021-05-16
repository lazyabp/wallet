using System;

namespace Lazy.Abp.WalletKit.RechargeProducts.Dtos
{
    [Serializable]
    public class RechargeProductCreateUpdateDto
    {
        public string Name { get; set; }

        public string Thumbnail { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }
}