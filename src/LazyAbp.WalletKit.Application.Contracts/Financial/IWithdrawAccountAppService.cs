using System;
using System.Threading.Tasks;
using LazyAbp.WalletKit.Financial.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.WalletKit.Financial
{
    public interface IWithdrawAccountAppService : IApplicationService
    {
        Task<WithdrawAccountDto> GetAsync(Guid id);

        Task<PagedResultDto<WithdrawAccountDto>> GetListAsync(GetWithdrawAccountListRequestDto input);

        Task<PagedResultDto<WithdrawAccountDto>> GetManagementListAsync(GetWithdrawAccountListRequestDto input);

        Task<WithdrawAccountDto> CreateAsync(CreateUpdateWithdrawAccountDto input);

        Task<WithdrawAccountDto> UpdateAsync(Guid id, CreateUpdateWithdrawAccountDto input);

        Task DeleteAsync(Guid id);
    }
}