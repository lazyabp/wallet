using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.Withdraws.Dtos
{
    public class WithdrawAccountListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public AccountType? AccountType { get; set; }
        public bool? IsDefault { get; set; }
        public string Filter { get; set; }
    }
}
