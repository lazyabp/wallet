using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.Withdraws.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.Withdraws
{
    public interface IWithdrawAccountAppService : IApplicationService
    {
        Task<WithdrawAccountDto> GetAsync(Guid id);

        Task<PagedResultDto<WithdrawAccountDto>> GetListAsync(WithdrawAccountListRequestDto input);

        Task<PagedResultDto<WithdrawAccountDto>> GetManagementListAsync(WithdrawAccountListRequestDto input);

        Task<WithdrawAccountDto> CreateAsync(WithdrawAccountCreateUpdateDto input);

        Task<WithdrawAccountDto> UpdateAsync(Guid id, WithdrawAccountCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}