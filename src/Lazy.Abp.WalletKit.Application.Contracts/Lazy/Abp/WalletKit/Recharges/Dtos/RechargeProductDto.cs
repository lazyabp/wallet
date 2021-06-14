using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.Recharges.Dtos
{
    [Serializable]
    public class RechargeProductDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Thumbnail { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int Quantity { get; set; }

        public int SoldQuantity { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }
    }
}