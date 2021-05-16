using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.RechargeProducts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.RechargeProducts
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