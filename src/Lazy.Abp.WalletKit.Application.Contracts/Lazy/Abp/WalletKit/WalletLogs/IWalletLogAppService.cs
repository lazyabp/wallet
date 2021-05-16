using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.WalletLogs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.WalletLogs
{
    public interface IWalletLogAppService : IApplicationService
    {
        Task<WalletLogDto> GetAsync(Guid id);

        Task<PagedResultDto<WalletLogDto>> GetListAsync(WalletLogListRequestDto input);

        Task<PagedResultDto<WalletLogDto>> GetManagementListAsync(WalletLogListRequestDto input);
    }
}