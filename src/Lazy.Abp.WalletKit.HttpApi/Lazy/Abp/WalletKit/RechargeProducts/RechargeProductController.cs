using Lazy.Abp.WalletKit.RechargeProducts.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.RechargeProducts
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("RechargeProduct")]
    [Route("api/walletkit/recharge-products")]
    public class RechargeProductController : WalletKitController, IRechargeProductAppService
    {
        private readonly IRechargeProductAppService _service;

        public RechargeProductController(IRechargeProductAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<RechargeProductDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<RechargeProductDto>> GetListAsync(RechargeProductListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<RechargeProductDto> CreateAsync(RechargeProductCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<RechargeProductDto> UpdateAsync(Guid id, RechargeProductCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
