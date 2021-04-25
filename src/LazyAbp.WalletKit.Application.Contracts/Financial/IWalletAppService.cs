using System;
using System.Threading.Tasks;
using LazyAbp.WalletKit.Financial.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.WalletKit.Financial
{
    public interface IWalletAppService : IApplicationService
    {
        Task<WalletDto> GetAsync();

        Task<PagedResultDto<WalletDto>> GetListAsync(GetWalletListRequestDto input);

        Task<WalletDto> ResetAsync(Guid userId);
    }
}