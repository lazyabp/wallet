using Lazy.Abp.WalletKit.WithdrawAccounts.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.WithdrawAccounts
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("WithdrawAccount")]
    [Route("api/walletkit/withdraw-accounts")]
    public class WithdrawAccountController : WalletKitController, IWithdrawAccountAppService
    {
        private readonly IWithdrawAccountAppService _service;

        public WithdrawAccountController(IWithdrawAccountAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<WithdrawAccountDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<WithdrawAccountDto>> GetListAsync(GetWithdrawAccountListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("management")]
        public Task<PagedResultDto<WithdrawAccountDto>> GetManagementListAsync(GetWithdrawAccountListRequestDto input)
        {
            return _service.GetManagementListAsync(input);
        }

        [HttpPost]
        public Task<WithdrawAccountDto> CreateAsync(CreateUpdateWithdrawAccountDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<WithdrawAccountDto> UpdateAsync(Guid id, CreateUpdateWithdrawAccountDto input)
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
