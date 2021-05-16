using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Lazy.Abp.WalletKit.RechargeOrders
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

        internal RechargeOrderItem(
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

        internal void Update(decimal itemPrice, int quantity)
        {
            ItemPrice = itemPrice;
            Quantity = quantity;
        }
    }
}
