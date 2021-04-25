using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    public class GetPaymentSettingListRequestDto : PagedAndSortedResultRequestDto
    {
       public PaymentGateway? Gateway { get; set; }

        public bool? IsActive { get; set; }

        public string Filter { get; set; }
    }
}
