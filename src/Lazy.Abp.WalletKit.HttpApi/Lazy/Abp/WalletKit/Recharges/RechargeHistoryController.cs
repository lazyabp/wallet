using System;
using Lazy.Abp.WalletKit.Recharges.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Lazy.Abp.WalletKit.Recharges
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("RechargeHistory")]
    [Route("/api/walletKit/recharge-histories")]
    public class RechargeHistoryController : WalletKitController, IRechargeHistoryAppService
    {
        private readonly IRechargeHistoryAppService _service;

        public RechargeHistoryController(IRechargeHistoryAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RechargeHistoryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<RechargeHistoryDto>> GetListAsync(RechargeHistoryListRequestDto input)
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