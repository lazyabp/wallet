using Lazy.Abp.WalletKit.PaymentSettings.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.WalletKit.PaymentSettings
{
    [RemoteService(Name = WalletKitRemoteServiceConsts.RemoteServiceName)]
    [Area("walletkit")]
    [ControllerName("PaymentSetting")]
    [Route("api/walletkit/payment-settings")]
    public class PaymentSettingController : WalletKitController, IPaymentSettingAppService
    {
        private readonly IPaymentSettingAppService _service;

        public PaymentSettingController(IPaymentSettingAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<PaymentSettingDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<PaymentSettingDto>> GetListAsync(GetPaymentSettingListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("alipay-settings")]
        public Task<PaymentSettingAlipayDto> GetAlipaySettingAsync()
        {
            return _service.GetAlipaySettingAsync();
        }

        [HttpGet]
        [Route("wepay-settings")]
        public Task<PaymentSettingWeixinDto> GetWinxinSettingAsync()
        {
            return _service.GetWinxinSettingAsync();
        }

        [HttpPut]
        [Route("alipay-settings")]
        public Task<PaymentSettingDto> UpdateAlipaySettingAsync(PaymentSettingAlipayDto input)
        {
            return _service.UpdateAlipaySettingAsync(input);
        }

        [HttpPut]
        [Route("wepay-settings")]
        public Task<PaymentSettingDto> UpdateWinxinSettingAsync(PaymentSettingWeixinDto input)
        {
            return _service.UpdateWinxinSettingAsync(input);
        }

        [HttpPut]
        [Route("{id}/set-active")]
        public Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            return _service.SetActiveAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
