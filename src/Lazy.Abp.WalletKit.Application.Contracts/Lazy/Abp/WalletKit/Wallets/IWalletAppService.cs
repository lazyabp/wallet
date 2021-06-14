using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.Wallets.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.Wallets
{
    public interface IWalletAppService : IApplicationService
    {
        Task<WalletDto> GetAsync();

        Task<PagedResultDto<WalletDto>> GetListAsync(WalletListRequestDto input);

        Task<WalletDto> IncreaseBalanceAsync(Guid userId, BalanceAdjustmentDto input);

        Task<WalletDto> DecreaseBalanceAsync(Guid userId, BalanceAdjustmentDto input);
    }
}