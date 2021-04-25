using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    public class GetWithdrawAccountListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public AccountType? AccountType { get; set; }
        public bool? IsDefault { get; set; }
        public string Filter { get; set; }
    }
}
