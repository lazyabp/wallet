using Lazy.Abp.WalletKit.RechargeOrders.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.RechargeOrders
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("RechargeOrder")]
    [Route("api/walletkit/recharge-orders")]
    public class RechargeOrderController : WalletKitController, IRechargeOrderAppService
    {
        private readonly IRechargeOrderAppService _service;

        public RechargeOrderController(IRechargeOrderAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<RechargeOrderDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<RechargeOrderDto>> GetListAsync(GetRechargeOrderListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("management")]
        public Task<PagedResultDto<RechargeOrderDto>> GetManagementListAsync(GetRechargeOrderListRequestDto input)
        {
            return _service.GetManagementListAsync(input);
        }

        [HttpPost]
        public Task<RechargeOrderDto> CreateAsync(CreateUpdateRechargeOrderDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}/add-item")]
        public Task<RechargeOrderDto> AddItemAsync(Guid id, ItemRequestDto input)
        {
            return _service.AddItemAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/remove-item")]
        public Task<RechargeOrderDto> RemoveItemAsync(Guid id, ItemRequestDto input)
        {
            return _service.RemoveItemAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/set-as-closed")]
        public Task<RechargeOrderDto> SetAsClosedAsync(Guid id)
        {
            return _service.SetAsClosedAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
