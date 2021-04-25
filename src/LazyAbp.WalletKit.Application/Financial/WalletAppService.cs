using System;
using LazyAbp.WalletKit.Permissions;
using LazyAbp.WalletKit.Financial.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using System.Collections.Generic;

namespace LazyAbp.WalletKit.Financial
{
    public class WalletAppService : WalletKitAppService, IWalletAppService
    {
        private readonly IWalletRepository _repository;
        
        public WalletAppService(IWalletRepository repository)
        {
            _repository = repository;
        }

        [Authorize(WalletKitPermissions.Wallet.Default)]
        public async Task<WalletDto> GetAsync()
        {
            var wallet = await _repository.GetByUserIdAsync(CurrentUser.GetId());
            if (null == wallet)
            {
                wallet = new Wallet(GuidGenerator.Create(), CurrentUser.TenantId, CurrentUser.GetId(), 0, 0);
                await _repository.InsertAsync(wallet);
            }

            return ObjectMapper.Map<Wallet, WalletDto>(wallet);
        }

        [Authorize(WalletKitPermissions.Wallet.Management)]
        public async Task<PagedResultDto<WalletDto>> GetListAsync(GetWalletListRequestDto input)
        {
            var count = await _repository.GetCountAsync(null, input.MinBalance, input.MaxBalance, input.HasLockedAmount, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, 
                null, input.MinBalance, input.MaxBalance, input.HasLockedAmount, input.Filter);

            return new PagedResultDto<WalletDto>(
                count,
                ObjectMapper.Map<List<Wallet>, List<WalletDto>>(list)
            );
        }

        [Authorize(WalletKitPermissions.Wallet.Reset)]
        public async Task<WalletDto> ResetAsync(Guid userId)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);
            wallet.Reset();

            return ObjectMapper.Map<Wallet, WalletDto>(wallet);
        }
    }
}
