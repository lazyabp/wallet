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

        Task<PagedResultDto<WalletDto>> GetListAsync(GetWalletListRequestDto input);

        Task<WalletDto> ResetAsync(Guid userId);
    }
}