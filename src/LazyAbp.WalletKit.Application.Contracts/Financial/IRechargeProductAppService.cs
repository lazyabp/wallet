using System;
using System.Threading.Tasks;
using LazyAbp.WalletKit.Financial.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.WalletKit.Financial
{
    public interface IRechargeProductAppService : IApplicationService
    {
        Task<RechargeProductDto> GetAsync(Guid id);

        Task<PagedResultDto<RechargeProductDto>> GetListAsync(GetRechargeProductListRequestDto input);

        Task<RechargeProductDto> CreateAsync(CreateUpdateRechargeProductDto input);

        Task<RechargeProductDto> UpdateAsync(Guid id, CreateUpdateRechargeProductDto input);

        Task DeleteAsync(Guid id);
    }
}