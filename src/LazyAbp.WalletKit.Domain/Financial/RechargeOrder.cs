using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.WalletKit.Financial
{
    public class RechargeOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public decimal Amount { get; private set; }

        public PaymentGateway? Gateway { get; private set; }

        public PaymentStatus Status { get; private set; }

        [MaxLength(FinancialConsts.MaxLength128)]
        public string OrderNo { get; private set; }

        [MaxLength(FinancialConsts.MaxLength128)]
        public string TradeNo { get; private set; }

        public DateTime? PaymentTime { get; private set; }

        public bool IsClosed { get; private set; }

        public List<RechargeOrderItem> Items { get; private set; }

        protected RechargeOrder()
        {
            Items = new List<RechargeOrderItem>();
        }

        public RechargeOrder(
            Guid id,
            Guid? tenantId,
            PaymentGateway? gateway
        ) : base(id)
        {
            TenantId = tenantId;
            Gateway = gateway;
            IsClosed = false;
        }

        public void AddItem(Guid rechargeProductId, decimal itemPrice, int quantity)
        {
            if (IsClosed)
                throw new Exception("OrderHasBeenClosed");

            if (itemPrice <= 0)
                Items.RemoveAll(q => q.RechargeProductId == rechargeProductId);

            if (quantity <= 0)
                Items.RemoveAll(q => q.RechargeProductId == rechargeProductId);

            var item = Items.FirstOrDefault(q => q.RechargeProductId == rechargeProductId);
            if (item == null)
            {
                Items.Add(new RechargeOrderItem(Id, rechargeProductId, itemPrice, quantity));
            }
            else
            {
                item.Update(itemPrice, quantity);
            }

            Amount = Items.Sum(q => q.ItemPrice * q.Quantity);
        }

        public void SetAsCancelled()
        {
            if (Status == PaymentStatus.NotPaid)
            {
                Status = PaymentStatus.Cancelled;
            }
        }

        public void SetAsFailed()
        {
            Status = PaymentStatus.Failed;
        }

        public void SetAsPaid(string tradeNo)
        {
            if (Status == PaymentStatus.NotPaid)
            {
                Status = PaymentStatus.Paid;
                TradeNo = tradeNo;
                PaymentTime = DateTime.Now;
            }
        }

        public void SetAsCompleted()
        {
            if (Status == PaymentStatus.Paid)
            {
                Status = PaymentStatus.Completed;
            }
        }

        public void SetOrderNo(string orderNo)
        {
            if (Status == PaymentStatus.NotPaid)
            {
                OrderNo = orderNo;
            }
        }

        public void SetAsClosed()
        {
            IsClosed = true;
        }
    }
}
