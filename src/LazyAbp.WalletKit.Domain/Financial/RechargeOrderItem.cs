using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace LazyAbp.WalletKit.Financial
{
    public class RechargeOrderItem : Entity
    {
        public Guid RechargeOrderId { get; private set; }

        public Guid RechargeProductId { get; private set; }

        public decimal ItemPrice { get; private set; }

        public int Quantity { get; private set; }

        public override object[] GetKeys()
        {
            return new object[] { RechargeOrderId, RechargeProductId };
        }

        protected RechargeOrderItem()
        {
        }

        public RechargeOrderItem(
            Guid rechargeOrderId,
            Guid rechargeProductId,
            decimal itemPrice,
            int quantity
        )
        {
            RechargeOrderId = rechargeOrderId;
            RechargeProductId = rechargeProductId;
            ItemPrice = itemPrice;
            Quantity = quantity;
        }

        public void Update(decimal itemPrice, int quantity)
        {
            ItemPrice = itemPrice;
            Quantity = quantity;
        }
    }
}
