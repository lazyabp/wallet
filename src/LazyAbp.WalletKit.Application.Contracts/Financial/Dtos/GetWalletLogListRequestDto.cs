using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    public class GetWalletLogListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public bool? IsOut { get; set; }
        public string TypeName { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime? CreationAfter { get; set; }
        public DateTime? CreationBefore { get; set; }
        public string Filter { get; set; }
    }
}
