using System;
using Lazy.Abp.WalletKit.Permissions;
using Lazy.Abp.WalletKit.PaymentSettings.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Json;
using Lazy.Abp.WalletKit.Settings;
using System.Collections.Generic;

namespace Lazy.Abp.WalletKit.PaymentSettings
{
    public class PaymentSettingAppService : WalletKitAppService, IPaymentSettingAppService
    {
        private readonly IPaymentSettingRepository _repository;
        private readonly IJsonSerializer _jsonSerializer;
        
        public PaymentSettingAppService(IPaymentSettingRepository repository,
            IJsonSerializer jsonSerializer)
        {
            _repository = repository;
            _jsonSerializer = jsonSerializer;
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Default)]
        public async Task<PaymentSettingDto> GetAsync(Guid id)
        {
            var setting = await _repository.GetAsync(id);

            return ObjectMapper.Map<PaymentSetting, PaymentSettingDto>(setting);
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Update)]
        public async Task<PaymentSettingAlipayDto> GetAlipaySettingAsync()
        {
            var setting = await _repository.GetByGatewayAsync(PaymentGateway.Alipay);

            if (null == setting)
            {
                setting = new PaymentSetting(GuidGenerator.Create(), CurrentUser.TenantId, PaymentGateway.Alipay, "", "", "", false);
                setting.SetSettings(_jsonSerializer.Serialize(new AlipaySetting()));
            }

            var result = ObjectMapper.Map<PaymentSetting, PaymentSettingAlipayDto>(setting);
            result.Settings = _jsonSerializer.Deserialize<AlipaySetting>(setting.Settings);

            return result;
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Update)]
        public async Task<PaymentSettingWeixinDto> GetWinxinSettingAsync()
        {
            var setting = await _repository.GetByGatewayAsync(PaymentGateway.WeiXin);

            if (null == setting)
            {
                setting = new PaymentSetting(GuidGenerator.Create(), CurrentUser.TenantId, PaymentGateway.WeiXin, "", "", "", false);
                setting.SetSettings(_jsonSerializer.Serialize(new WeiXinSetting()));
            }

            var result = ObjectMapper.Map<PaymentSetting, PaymentSettingWeixinDto>(setting);
            result.Settings = _jsonSerializer.Deserialize<WeiXinSetting>(setting.Settings);

            return result;
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Default)]
        public async Task<PagedResultDto<PaymentSettingDto>> GetListAsync(PaymentSettingListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.Gateway, input.IsActive, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Gateway, input.IsActive, input.Filter);

            return new PagedResultDto<PaymentSettingDto>(
                count,
                ObjectMapper.Map<List<PaymentSetting>, List<PaymentSettingDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Update)]
        public async Task<PaymentSettingDto> UpdateAlipaySettingAsync(PaymentSettingAlipayDto input)
        {
            var setting = await _repository.GetByGatewayAsync(PaymentGateway.Alipay);

            if (null == setting)
            {
                setting = new PaymentSetting(GuidGenerator.Create(), CurrentUser.TenantId, PaymentGateway.Alipay, input.GatewayUrl, input.ReturnUrl, input.NotifyUrl, input.IsActive);
                setting.SetSettings(_jsonSerializer.Serialize(input.Settings));

                await _repository.InsertAsync(setting);
            }
            else
            {
                setting.Update(input.GatewayUrl, input.ReturnUrl, input.NotifyUrl, input.IsActive);
                setting.SetSettings(_jsonSerializer.Serialize(input.Settings));

                await _repository.UpdateAsync(setting);
            }

            return ObjectMapper.Map<PaymentSetting, PaymentSettingDto>(setting);
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Update)]
        public async Task<PaymentSettingDto> UpdateWinxinSettingAsync(PaymentSettingWeixinDto input)
        {
            var setting = await _repository.GetByGatewayAsync(PaymentGateway.WeiXin);

            if (null == setting)
            {
                setting = new PaymentSetting(GuidGenerator.Create(), CurrentUser.TenantId, PaymentGateway.WeiXin, input.GatewayUrl, input.ReturnUrl, input.NotifyUrl, input.IsActive);
                setting.SetSettings(_jsonSerializer.Serialize(input.Settings));

                await _repository.InsertAsync(setting);
            }
            else
            {
                setting.Update(input.GatewayUrl, input.ReturnUrl, input.NotifyUrl, input.IsActive);
                setting.SetSettings(_jsonSerializer.Serialize(input.Settings));

                await _repository.UpdateAsync(setting);
            }

            return ObjectMapper.Map<PaymentSetting, PaymentSettingDto>(setting);
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Update)]
        public async Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            var setting = await _repository.GetAsync(id);
            setting.SetActive(input.IsActive);
        }

        [Authorize(WalletKitPermissions.PaymentSetting.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
