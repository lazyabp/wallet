using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.WalletKit.RechargeProducts
{
    public class RechargeProduct : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        [MaxLength(FinancialConsts.MaxLength255)]
        public string Name { get; private set; }

        [MaxLength(FinancialConsts.MaxLength255)]
        public string Thumbnail { get; private set; }

        public decimal RetailPrice { get; private set; }

        public decimal SalePrice { get; private set; }

        public int Quantity { get; private set; }

        public int SoldQuantity { get; private set; }

        public string Description { get; private set; }

        public bool IsActive { get; private set; }

        public int DisplayOrder { get; private set; }

        protected RechargeProduct()
        {
        }

        public RechargeProduct(
            Guid id,
            Guid? tenantId,
            string name,
            string thumbnail,
            decimal retailPrice,
            decimal salePrice,
            int quantity,
            string description,
            bool isActive,
            int displayOrder
        ) : base(id)
        {
            TenantId = tenantId;
            Name = name;
            Thumbnail = thumbnail;
            RetailPrice = retailPrice;
            SalePrice = salePrice;
            Quantity = quantity;
            Description = description;
            IsActive = isActive;
            DisplayOrder = displayOrder;
        }

        public void Update(
            string name,
            string thumbnail,
            decimal retailPrice,
            decimal salePrice,
            int quantity,
            string description,
            bool isActive,
            int displayOrder
        )
        {
            Name = name;
            Thumbnail = thumbnail;
            RetailPrice = retailPrice;
            SalePrice = salePrice;
            Quantity = quantity;
            Description = description;
            IsActive = isActive;
            DisplayOrder = displayOrder;
        }

        public void SetSoldQuantity(int soldQuantity)
        {
            SoldQuantity = soldQuantity;
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}
