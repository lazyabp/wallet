using Lazy.Abp.WalletKit.Wallets.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.Wallets
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("Wallet")]
    [Route("api/walletkit/wallets")]
    public class WalletController : WalletKitController, IWalletAppService
    {
        private readonly IWalletAppService _service;

        public WalletController(IWalletAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("my-wallet")]
        public Task<WalletDto> GetAsync()
        {
            return _service.GetAsync();
        }

        [HttpGet]
        public Task<PagedResultDto<WalletDto>> GetListAsync(WalletListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPut]
        [Route("{userId}/increase-balance")]
        public Task<WalletDto> IncreaseBalanceAsync(Guid userId, BalanceAdjustmentDto input)
        {
            return _service.IncreaseBalanceAsync(userId, input);
        }

        [HttpPut]
        [Route("{userId}/decrease-balance")]
        public Task<WalletDto> DecreaseBalanceAsync(Guid userId, BalanceAdjustmentDto input)
        {
            return _service.DecreaseBalanceAsync(userId, input);
        }
    }
}
