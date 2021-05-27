using System;
using Lazy.Abp.WalletKit.WalletActions.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Lazy.Abp.WalletKit.WalletActions
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("WalletAction")]
    [Route("/api/walletKit/wallet-actions/management")]
    public class WalletActionAdminController : WalletKitController, IWalletActionAdminAppService
    {
        private readonly IWalletActionAdminAppService _service;

        public WalletActionAdminController(IWalletActionAdminAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<WalletActionDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<WalletActionDto>> GetListAsync(WalletActionListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}