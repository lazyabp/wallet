using Lazy.Abp.WalletKit.Permissions;
using Lazy.Abp.WalletKit.Recharges.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace Lazy.Abp.WalletKit.Recharges
{
    public class RechargeHistoryAdminAppService : WalletKitAppService, IRechargeHistoryAdminAppService
    {
        private readonly IRechargeHistoryRepository _repository;

        public RechargeHistoryAdminAppService(IRechargeHistoryRepository repository)
        {
            _repository = repository;
        }

        [Authorize(WalletKitPermissions.RechargeHistory.Default)]
        public async Task<RechargeHistoryDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return ObjectMapper.Map<RechargeHistory, RechargeHistoryDto>(result);
        }

        [Authorize(WalletKitPermissions.RechargeHistory.Default)]
        public async Task<PagedResultDto<RechargeHistoryDto>> GetListAsync(RechargeHistoryListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.RechargeProductId,
                input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(),
                input.RechargeProductId, input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<RechargeHistoryDto>(
                totalCount,
                ObjectMapper.Map<List<RechargeHistory>, List<RechargeHistoryDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.RechargeHistory.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(result);
        }
    }
}
