using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.Recharges.Dtos
{
    public class RechargeHistoryListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? RechargeProductId { get; set; }

        public decimal? MinPaidAmount { get; set; }

        public decimal? MaxPaidAmount { get; set; }

        public DateTime? CreationAfter { get; set; }

        public DateTime? CreationBefore { get; set; }

        public string Filter { get; set; }
    }
}
