using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.PaymentSettings.Dtos
{
    public class PaymentSettingListRequestDto : PagedAndSortedResultRequestDto
    {
       public PaymentGateway? Gateway { get; set; }

        public bool? IsActive { get; set; }

        public string Filter { get; set; }
    }
}
