using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.Recharges.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.Recharges
{
    public interface IRechargeProductAppService : IApplicationService
    {
        Task<RechargeProductDto> GetAsync(Guid id);

        Task<PagedResultDto<RechargeProductDto>> GetListAsync(RechargeProductListRequestDto input);

        Task<RechargeProductDto> CreateAsync(RechargeProductCreateUpdateDto input);

        Task<RechargeProductDto> UpdateAsync(Guid id, RechargeProductCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}