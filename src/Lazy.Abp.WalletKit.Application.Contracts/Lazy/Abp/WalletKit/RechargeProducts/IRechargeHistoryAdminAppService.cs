using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.Recharges.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.Recharges
{
    public interface IRechargeHistoryAdminAppService : IApplicationService
    {
        Task<RechargeHistoryDto> GetAsync(Guid id);

        Task<PagedResultDto<RechargeHistoryDto>> GetListAsync(RechargeHistoryListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}