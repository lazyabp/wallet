using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.Wallets.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.Wallets
{
    public interface IWalletLogAppService : IApplicationService
    {
        Task<WalletLogDto> GetAsync(Guid id);

        Task<PagedResultDto<WalletLogDto>> GetListAsync(WalletLogListRequestDto input);

        Task<PagedResultDto<WalletLogDto>> GetManagementListAsync(WalletLogListRequestDto input);
    }
}