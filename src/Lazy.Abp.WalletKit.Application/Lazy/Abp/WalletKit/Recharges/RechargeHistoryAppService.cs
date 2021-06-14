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
    [Authorize]
    public class RechargeHistoryAppService : WalletKitAppService, IRechargeHistoryAppService
    {
        private readonly IRechargeHistoryRepository _repository;

        public RechargeHistoryAppService(IRechargeHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<RechargeHistoryDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return ObjectMapper.Map<RechargeHistory, RechargeHistoryDto>(result);
        }

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

        public async Task DeleteAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(result);
        }
    }
}
