using System;
using System.Threading.Tasks;
using LazyAbp.WalletKit.Financial.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.WalletKit.Financial
{
    public interface IWalletLogAppService : IApplicationService
    {
        Task<WalletLogDto> GetAsync(Guid id);

        Task<PagedResultDto<WalletLogDto>> GetListAsync(GetWalletLogListRequestDto input);

        Task<PagedResultDto<WalletLogDto>> GetManagementListAsync(GetWalletLogListRequestDto input);
    }
}