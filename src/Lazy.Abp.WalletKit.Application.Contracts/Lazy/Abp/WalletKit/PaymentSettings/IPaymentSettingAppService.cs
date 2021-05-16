using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.PaymentSettings.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.PaymentSettings
{
    public interface IPaymentSettingAppService : IApplicationService
    {
        Task<PaymentSettingAlipayDto> GetAlipaySettingAsync();

        Task<PaymentSettingWeixinDto> GetWinxinSettingAsync();

        Task<PaymentSettingDto> GetAsync(Guid id);

        Task<PagedResultDto<PaymentSettingDto>> GetListAsync(GetPaymentSettingListRequestDto input);
    
        Task<PaymentSettingDto> UpdateAlipaySettingAsync(PaymentSettingAlipayDto input);

        Task<PaymentSettingDto> UpdateWinxinSettingAsync(PaymentSettingWeixinDto input);

        Task SetActiveAsync(Guid id, SetActiveRequestDto input);

        Task DeleteAsync(Guid id);
    }
}