﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    public class GetRechargeOrderListRequestDto : PagedAndSortedResultRequestDto
    {
        public PaymentGateway? Gateway { get; set; }

        public PaymentStatus? Status { get; set; }

        public bool? IsClosed { get; set; }

        public decimal? MinAmount { get; set; }

        public decimal? MaxAmount { get; set; }

        public DateTime? CreationAfter { get; set; }

        public DateTime? CreationBefore { get; set; }

        public string Filter { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
