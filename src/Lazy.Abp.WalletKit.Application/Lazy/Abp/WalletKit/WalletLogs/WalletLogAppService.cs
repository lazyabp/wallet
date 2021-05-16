using System;
using Lazy.Abp.WalletKit.Permissions;
using Lazy.Abp.WalletKit.WalletLogs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using System.Collections.Generic;

namespace Lazy.Abp.WalletKit.WalletLogs
{
    public class WalletLogAppService : WalletKitAppService, IWalletLogAppService
    {
        private readonly IWalletLogRepository _repository;
        
        public WalletLogAppService(IWalletLogRepository repository)
        {
            _repository = repository;
        }

        [Authorize(WalletKitPermissions.WalletLog.Default)]
        public async Task<WalletLogDto> GetAsync(Guid id)
        {
            var log = await _repository.GetAsync(id);

            return ObjectMapper.Map<WalletLog, WalletLogDto>(log);
        }

        [Authorize(WalletKitPermissions.WalletLog.Default)]
        public async Task<PagedResultDto<WalletLogDto>> GetListAsync(GetWalletLogListRequestDto input)
        {
            var count = await _repository.GetCountAsync(CurrentUser.GetId(), input.IsOut, input.TypeName, 
                input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(), 
                input.IsOut, input.TypeName, input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<WalletLogDto>(
                count,
                ObjectMapper.Map<List<WalletLog>, List<WalletLogDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.WalletLog.Management)]
        public async Task<PagedResultDto<WalletLogDto>> GetManagementListAsync(GetWalletLogListRequestDto input)
        {
            var count = await _repository.GetCountAsync(null, input.IsOut, input.TypeName,
                input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, null,
                input.IsOut, input.TypeName, input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<WalletLogDto>(
                count,
                ObjectMapper.Map<List<WalletLog>, List<WalletLogDto>>(list)
            );
        }
    }
}
