﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.WalletKit.Financial.Dtos
{
    public class GetWalletListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public decimal? MinBalance { get; set; }
        public decimal? MaxBalance { get; set; }
        public bool HasLockedAmount { get; set; }
        public string Filter { get; set; }
    }
}
