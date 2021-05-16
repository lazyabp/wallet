using Lazy.Abp.WalletKit.WalletLogs.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.WalletLogs
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("WalletLog")]
    [Route("api/walletkit/wallet-logs")]
    public class WalletLogController : WalletKitController, IWalletLogAppService
    {
        private readonly IWalletLogAppService _service;

        public WalletLogController(IWalletLogAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<WalletLogDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<WalletLogDto>> GetListAsync(GetWalletLogListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("management")]
        public Task<PagedResultDto<WalletLogDto>> GetManagementListAsync(GetWalletLogListRequestDto input)
        {
            return _service.GetManagementListAsync(input);
        }
    }
}
