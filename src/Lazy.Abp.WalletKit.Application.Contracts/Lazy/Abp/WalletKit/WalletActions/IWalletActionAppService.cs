using System;
using System.Threading.Tasks;
using Lazy.Abp.WalletKit.WalletActions.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.WalletKit.WalletActions
{
    public interface IWalletActionAppService : IApplicationService
    {
        Task<WalletActionDto> GetAsync(Guid id);

        Task<PagedResultDto<WalletActionDto>> GetListAsync(WalletActionListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}