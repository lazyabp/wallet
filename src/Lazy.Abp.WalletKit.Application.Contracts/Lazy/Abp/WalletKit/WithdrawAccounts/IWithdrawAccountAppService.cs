using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.WithdrawAccounts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.WithdrawAccounts
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