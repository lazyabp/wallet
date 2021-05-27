using Lazy.Abp.WalletKit.WalletActions.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace Lazy.Abp.WalletKit.WalletActions
{
    [Authorize]
    public class WalletActionAppService : WalletKitAppService, IWalletActionAppService
    {
        private readonly IWalletActionRepository _repository;

        public WalletActionAppService(IWalletActionRepository repository)
        {
            _repository = repository;
        }

        public async Task<WalletActionDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return ObjectMapper.Map<WalletAction, WalletActionDto>(result);
        }

        public async Task<PagedResultDto<WalletActionDto>> GetListAsync(WalletActionListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.RechargeProductId,
                input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(),
                input.RechargeProductId, input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<WalletActionDto>(
                totalCount,
                ObjectMapper.Map<List<WalletAction>, List<WalletActionDto>>(list)
            );
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(result);
        }
    }
}
